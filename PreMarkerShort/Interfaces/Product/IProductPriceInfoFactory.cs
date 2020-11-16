namespace PreMarkerShort.Interfaces.Product
{
    public interface IProductPriceInfoFactory
    {
        IProductPriceInfo CreateProductPriceInfo(IProduct product);
    }
}