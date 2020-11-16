using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Print
{
    public class SimpleReceiptGenerator : IReceiptGenerator
    {
        public string Generate(IEnumerable<IProductPriceInfo> productInfos, ICartCoupon cartCoupon)
        {
            if (productInfos == null) throw new ArgumentNullException(nameof(productInfos));

            var sb = new StringBuilder();

            sb.AppendLine("Tnx!");
            sb.AppendLine();

            sb.AppendLine("Name...Price...Qty...Total Price");

            foreach (var productInfo in productInfos)
            {
                sb.AppendLine($"{productInfo.Product.Name}...{productInfo.Product.Price}p...{productInfo.InCartQty}...{productInfo.GetTotalPrice()}");
                if (productInfo.Coupon != null && productInfo.Coupon.Discount > 0)
                {
                    sb.AppendLine($"Product discount: {productInfo.Coupon.Discount*100}%");
                }
                sb.AppendLine();
            }

            sb.AppendLine();

            if (cartCoupon != null && cartCoupon.Discount > 0)
            {
                sb.AppendLine($"Total: {cartCoupon.GetTotalPrice(productInfos)}");
                sb.AppendLine($"Cart discount: {cartCoupon.Discount * 100}%");
            }
            else
            {
                sb.AppendLine($"Total: {productInfos.Sum(p => p.GetTotalPrice())}");
            }
            
            return sb.ToString();
        }
    }
}