using System.Collections.Generic;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product.ProductCommands
{
    public class ProductCommandsFactory : IProductCommandsFactory
    {
        public ICommand CreateAddProductCommand(IList<IProductPriceInfo> products, IProductPriceInfo product)
        {
            return new ProductAddCommand(products, product);
        }

        public ICommand CreateRemoveProductCommand(IList<IProductPriceInfo> products, IProductPriceInfo product)
        {
            return new ProductRemoveCommand(products, product);
        }

        public ICommand CreateChangeProductCountCommand(IProductPriceInfo product, int count)
        {
            return new ProductChangeCountCommand(product, count);
        }
    }
}