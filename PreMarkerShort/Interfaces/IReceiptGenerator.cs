using System.Collections.Generic;
using PreMarkerShort.Interfaces.Cart;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Interfaces
{
    public interface IReceiptGenerator
    {
        string Generate(IEnumerable<IProductPriceInfo> products, ICartCoupon cartCoupon);
    }
}