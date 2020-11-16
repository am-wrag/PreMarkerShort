namespace PreMarkerShort.Interfaces.Product
{
    public interface IProductPriceInfo
    {
        decimal GetTotalPrice();
        int InCartQty { get; }

        IProduct Product { get; }
        IProductCoupon Coupon { get; }

        void SetProductCoupon(IProductCoupon coupon);
        void SetQty(int newQty);
    }
}