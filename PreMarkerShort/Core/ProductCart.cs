using System;
using System.Collections.Generic;
using System.Linq;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Core
{
    public class ProductCart : IProductCart
    {
        public IList<IProductPriceInfo> Products { get; } = new List<IProductPriceInfo>();
        public ICartCoupon CartCoupon { get; private set; }

        private readonly ICommandManager _commandManager;
        private readonly ICouponCommandFactory _productCouponFactory;
        private readonly IProductCommandsFactory _productCommandFactory;

        public ProductCart(
            ICommandManager commandManager,
            ICouponCommandFactory productCouponFactory,
            IProductCommandsFactory productCommandFactory)
        {
            _commandManager = commandManager ?? throw new ArgumentNullException(nameof(commandManager));
            _productCouponFactory = productCouponFactory ?? throw new ArgumentNullException(nameof(productCouponFactory));
            _productCommandFactory = productCommandFactory ?? throw new ArgumentNullException(nameof(productCommandFactory));
        }

        public decimal GetTotalPrice()
        {
            return CartCoupon?.GetTotalPrice(Products) ?? Products.Sum(p => p.GetTotalPrice());
        }

        public void AddProduct(IProductPriceInfo product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var addProductCommand = _productCommandFactory.CreateAddProductCommand(Products, product);
            _commandManager.ExecuteCommand(addProductCommand);
        }

        public void RemoveProduct(IProductPriceInfo product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var removeProductCommand = _productCommandFactory.CreateRemoveProductCommand(Products, product);
            _commandManager.ExecuteCommand(removeProductCommand);
        }

        public void ChangeProductQty(IProductPriceInfo product, int newProductQty)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var changeProductCountCommand = _productCommandFactory.CreateChangeProductCountCommand(product, newProductQty);
            _commandManager.ExecuteCommand(changeProductCountCommand);
        }

        public void SetProductCoupon(IProductPriceInfo product, IProductCoupon coupon)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (coupon == null) throw new ArgumentNullException(nameof(coupon));

            var addCouponCommand = _productCouponFactory.CreateSetCouponCommand(product, coupon);

            _commandManager.ExecuteCommand(addCouponCommand);
        }
        
        public void ChangeProductCount(IProductPriceInfo product, int newProductCount)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (newProductCount < 0) throw new ArgumentOutOfRangeException(nameof(newProductCount));

            var changeProductCountCommand = _productCommandFactory.CreateChangeProductCountCommand(product, newProductCount);
            _commandManager.ExecuteCommand(changeProductCountCommand);
        }      

        public void SetCartCoupon(ICartCoupon cartCoupon)
        {
            CartCoupon = cartCoupon;
        }

        public void Undo()
        {
            _commandManager.Undo();
        }

        public void Redo()
        {
            _commandManager.Redo();
        }
    }
}