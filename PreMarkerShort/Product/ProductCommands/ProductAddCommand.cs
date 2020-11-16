using System;
using System.Collections.Generic;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product.ProductCommands
{
    public class ProductAddCommand : ICommand
    {
        private readonly IList<IProductPriceInfo> _products;
        private readonly IProductPriceInfo _product;

        public ProductAddCommand(IList<IProductPriceInfo> products, IProductPriceInfo product)
        {
            _products = products ?? throw new ArgumentNullException(nameof(products));
            _product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public void Execute()
        {
            _products.Add(_product);
        }

        public void Undo()
        {
            if(!_products.Contains(_product)) return;

            _products.Remove(_product);
        }
    }
}