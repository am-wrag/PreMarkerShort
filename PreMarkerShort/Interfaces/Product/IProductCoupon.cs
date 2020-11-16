namespace PreMarkerShort.Interfaces.Product
{
    public interface IProductCoupon : ICoupon
    {
        decimal GetTotalPrice(IProductPriceInfo product);
    }
}