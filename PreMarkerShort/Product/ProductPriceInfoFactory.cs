using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product
{
    public class ProductPriceInfoFactory : IProductPriceInfoFactory
    {
        public IProductPriceInfo CreateProductPriceInfo(IProduct product)
        {
            return new ProductPriceInfo(product);
        }
    }
}