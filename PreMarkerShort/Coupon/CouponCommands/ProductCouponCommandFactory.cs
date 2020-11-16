using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Coupon.CouponCommands
{
    public class ProductCouponCommandFactory : ICouponCommandFactory
    {
        public ICommand CreateSetCouponCommand(IProductPriceInfo product, IProductCoupon newCoupon)
        {
            return new SetCouponToProductCommand(product, newCoupon);
        }
    }
}