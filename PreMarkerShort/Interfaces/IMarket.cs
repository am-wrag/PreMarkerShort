using PreMarkerShort.Interfaces.Cart;

namespace PreMarkerShort.Interfaces
{
    public interface IMarket
    {
        decimal GetTotalPrice();
        IProductCart ProductCart { get; }
        void SetCartCoupon(ICartCoupon cartCoupon);
    }
}