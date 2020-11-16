using System;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Coupon
{
    public class DiscountProductCoupon : IProductCoupon
    {
        public string Name => $"Скидка {Discount}% при покупке не менее {_minimumProductCountForDiscount} товаров";
        public decimal Discount { get; }
        private readonly int _minimumProductCountForDiscount;

        public DiscountProductCoupon(decimal priceModifier, int minimumProductCount)
        {
            Discount = priceModifier;
            _minimumProductCountForDiscount = minimumProductCount;
        }

        public decimal GetTotalPrice(IProductPriceInfo productInfo)
        {
            if (productInfo == null) throw new ArgumentNullException(nameof(productInfo));
            if (productInfo.Product.Price < 0) throw new ArgumentOutOfRangeException(nameof(productInfo.Product.Price));
            if (productInfo.InCartQty < 0) throw new ArgumentOutOfRangeException(nameof(productInfo.InCartQty));

            var totalPriceWithNoDiscount = productInfo.InCartQty * productInfo.Product.Price;

            return productInfo.InCartQty >= _minimumProductCountForDiscount
                ? totalPriceWithNoDiscount * (1 - Discount)
                : totalPriceWithNoDiscount;
        }

       

        public IProductCoupon Copy()
        {
            return new DiscountProductCoupon(Discount, _minimumProductCountForDiscount);
        }
    }
}