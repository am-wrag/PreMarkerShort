using System;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product
{
    public class Marmelade : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int StockQty { get; set; }
        public int Length { get; }

        public Marmelade(string name, decimal price, int stockQty, int length)
        {
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (stockQty <= 0) throw new ArgumentOutOfRangeException(nameof(stockQty));
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            StockQty = stockQty;
            Length = length;
        }
    }
}