using System.Collections.Generic;
using PreMarkerShort.Core;
using PreMarkerShort.Coupon;
using PreMarkerShort.Coupon.CouponCommands;
using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Cart;
using PreMarkerShort.Interfaces.Product;
using PreMarkerShort.Print;
using PreMarkerShort.Product;
using PreMarkerShort.Product.ProductCommands;

namespace PreMarkerShort
{
    public class Sample
    {
        public static void TestRun()
        {
            var cart = CreateTestCart();
            FillCart(cart);

            var market = CreateTestMarket(cart);

            PrintReceipt(market.ProductCart.Products, market.ProductCart.CartCoupon);
        }

        private static void PrintReceipt(IEnumerable<IProductPriceInfo> cartProducts, ICartCoupon cartCartCoupon)
        {
            var receiptText = new SimpleReceiptGenerator().Generate(cartProducts, cartCartCoupon);
            new ConsolePrinter().Print(receiptText);
        }

        private static void FillCart(IProductCart cart)
        {
            var candyProductInfo = new ProductPriceInfo(new Candy("Vanilla", 50, 10, 5));
            candyProductInfo.SetQty(4);

            var productCoupon = new DiscountProductCoupon(0.25M, 3);
            candyProductInfo.SetProductCoupon(productCoupon);

            cart.AddProduct(candyProductInfo);

            var juiceProductInfo = new ProductPriceInfo(new Juice("Orange", 25, 50, "red"));
            juiceProductInfo.SetQty(2);
            cart.AddProduct(juiceProductInfo);
        }
        private static IMarket CreateTestMarket(IProductCart cart)
        {
            var marketCommandManager = new CommandManager();
            var cartCouponCommands = new CartCouponCommandFactory();

            var market = new Market(marketCommandManager, cart, cartCouponCommands);
            var cartCoupon = new DiscountCartCoupon(0.2M);
            market.SetCartCoupon(cartCoupon);

            return market;
        }

        private static IProductCart CreateTestCart()
        {
            var cartCommandManager = new CommandManager();
            var couponFactory = new ProductCouponCommandFactory();
            var commandFactory = new ProductCommandsFactory();
            return new ProductCart(cartCommandManager, couponFactory, commandFactory);
        }
    }
}