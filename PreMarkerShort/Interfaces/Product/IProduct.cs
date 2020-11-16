namespace PreMarkerShort.Interfaces.Product
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        int StockQty { get; }
    }
}