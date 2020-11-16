using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product
{
    public class Juice : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int StockQty { get; set; }
        public string Color { get; }

        public Juice(string name, decimal price, int stockQty, string color)
        {
            Name = name;
            Price = price;
            StockQty = stockQty;
            Color = color;
        }
    }
}