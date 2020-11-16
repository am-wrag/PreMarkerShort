using System;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Product
{
    public class ProductPriceInfo : IProductPriceInfo
    {
        public IProduct Product { get; }
        public IProductCoupon Coupon { get; private set; }
        
        public int InCartQty { get; set; }

        public ProductPriceInfo(IProduct product)
        {
            Product = product;
        }

        public decimal GetTotalPrice()
        {
            return Coupon?.GetTotalPrice(this) ?? Product.Price * InCartQty;
        }

        public void SetProductCoupon(IProductCoupon coupon)
        {
            Coupon = coupon;
        }

        public void SetQty(int newQty)
        {
            if (newQty <= 0) throw new ArgumentOutOfRangeException(nameof(newQty));
            InCartQty = newQty;
        }
    }
}