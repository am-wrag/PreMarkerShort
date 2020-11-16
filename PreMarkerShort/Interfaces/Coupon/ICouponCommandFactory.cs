using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Interfaces
{
    public interface ICouponCommandFactory
    {
        ICommand CreateSetCouponCommand(IProductPriceInfo product, IProductCoupon newCoupon);
    }
}