using System.Collections.Generic;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Interfaces.Cart
{
    public interface ICartCoupon : ICoupon
    {
        decimal GetTotalPrice(IEnumerable<IProductPriceInfo> products);
    }
}