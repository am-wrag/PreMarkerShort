using System;
using System.Linq;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;

namespace PreMarkerShort.Core
{
    public class Market : IMarket
    {
        public IProductCart ProductCart { get; }

        private readonly ICommandManager _commandManager;
        private readonly ICartCouponCommandFactory _couponCommandFactory;

        public Market(ICommandManager commandManager, 
            IProductCart cartManager,
            ICartCouponCommandFactory couponCommandFactory)
        {
            _commandManager = commandManager ?? throw new ArgumentNullException(nameof(commandManager));
            _couponCommandFactory = couponCommandFactory ?? throw new ArgumentNullException(nameof(couponCommandFactory));
            ProductCart = cartManager ?? throw new ArgumentNullException(nameof(cartManager));
        }

        public decimal GetTotalPrice()
        {
            var productPrice = ProductCart.Products.Sum(p => p.GetTotalPrice());

            return ProductCart.CartCoupon?.GetTotalPrice(ProductCart.Products) ?? productPrice;
        }

        public void SetCartCoupon(ICartCoupon cartCoupon)
        {
            var setCouponCommand = _couponCommandFactory.CreateSetCartCouponCommand(ProductCart, cartCoupon);
            _commandManager.ExecuteCommand(setCouponCommand);
        }
    }
}