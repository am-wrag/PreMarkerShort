using System.Collections.Generic;

namespace PreMarkerShort.Interfaces.Product
{
    public interface IProductCommandsFactory
    {
        ICommand CreateAddProductCommand(IList<IProductPriceInfo> products, IProductPriceInfo product);
        ICommand CreateRemoveProductCommand(IList<IProductPriceInfo> products, IProductPriceInfo product);
        ICommand CreateChangeProductCountCommand(IProductPriceInfo product, int count);
    }
}