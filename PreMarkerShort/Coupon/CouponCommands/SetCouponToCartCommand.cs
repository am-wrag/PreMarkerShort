using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;

namespace PreMarkerShort.Coupon.CouponCommands
{
    internal class SetCouponToCartCommand : ICommand
    {
        private readonly IProductCart _cart;
        private readonly ICartCoupon _newCoupon;
        private readonly ICartCoupon _previousCoupon;

        public SetCouponToCartCommand(IProductCart cart, ICartCoupon cartCoupon)
        {
            _cart = cart;
            _newCoupon = cartCoupon;
            _previousCoupon = _cart.CartCoupon;
        }

        public void Execute()
        {
            _cart.SetCartCoupon(_newCoupon);
        }

        public void Undo()
        {
            _cart.SetCartCoupon(_previousCoupon);
        }
    }
}