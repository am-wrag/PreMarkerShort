using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;

namespace PreMarkerShort.Coupon.CouponCommands
{
    public class CartCouponCommandFactory : ICartCouponCommandFactory
    {
       
        public ICommand CreateSetCartCouponCommand(IProductCart cart, ICartCoupon cartCoupon)
        {
            return new SetCouponToCartCommand(cart, cartCoupon);
        }
    }
}