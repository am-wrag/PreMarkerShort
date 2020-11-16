using System;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product.ProductCommands
{
    public class ProductChangeCountCommand : ICommand
    {
        private readonly IProductPriceInfo _product;
        private readonly int _newProductCount;
        private readonly int _oldProductCount;

        public ProductChangeCountCommand(IProductPriceInfo product, int newProductCount)
        {
            if (newProductCount <= 0) throw new ArgumentOutOfRangeException(nameof(newProductCount));
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _oldProductCount = _product.Product.StockQty;
            _newProductCount = newProductCount;
        }

        public void Execute()
        {
            _product.SetQty(_newProductCount);
        }

        public void Undo()
        {
            _product.SetQty(_oldProductCount);
        }
    }
}