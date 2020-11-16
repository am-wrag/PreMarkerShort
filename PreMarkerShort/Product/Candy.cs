using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product
{
    public class Candy : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int StockQty { get; set; }
        public int Wight { get; set; }

        public Candy(string name, decimal price, int stockQty, int wight)
            
        {
            Wight = wight;
            Price = price;
            Name = name;
            StockQty = stockQty;
        }
    }
}