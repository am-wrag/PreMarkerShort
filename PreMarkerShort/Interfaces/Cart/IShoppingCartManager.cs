using System.Collections.Generic;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Interfaces.Cart
{
    public interface IProductCart
    {
        IList<IProductPriceInfo> Products { get; }
        ICartCoupon CartCoupon { get;  }
        void AddProduct(IProductPriceInfo product);
        void RemoveProduct(IProductPriceInfo product);
        void ChangeProductQty(IProductPriceInfo product, int newProductQty);
        void SetProductCoupon(IProductPriceInfo product, IProductCoupon productCoupon);
        void SetCartCoupon(ICartCoupon cartCoupon);
    }
}