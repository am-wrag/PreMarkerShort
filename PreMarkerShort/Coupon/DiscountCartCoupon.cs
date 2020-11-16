using System.Collections.Generic;
using System.Linq;
using PreMarkerShort.Interfaces.Cart;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Coupon
{ 

    public class DiscountCartCoupon : ICartCoupon
    {
        public string Name => $"Подарочный купон {Discount}% на всю корзину!";
        public decimal Discount { get; }

        public DiscountCartCoupon(decimal discountPercent)
        {
            Discount = discountPercent;
        }

        public decimal GetTotalPrice(IEnumerable<IProductPriceInfo> products)
        {
            return (1 - Discount) * products.Sum(p => p.GetTotalPrice());
        }

        public ICartCoupon Copy()
        {
            return new DiscountCartCoupon(Discount);
        }
    }
}