using PreMarkerShort.Interfaces;
using PreMarkerShort.Interfaces.Product;

namespace PreMarkerShort.Coupon.CouponCommands
{
    internal class SetCouponToProductCommand : ICommand
    {
        private readonly IProductPriceInfo _product;
        private readonly IProductCoupon _newCoupon;
        private readonly IProductCoupon _previousCoupon;

        public SetCouponToProductCommand(IProductPriceInfo product, IProductCoupon newProductCoupon)
        {
            _product = product;
            _newCoupon = newProductCoupon;
            _previousCoupon = _product.Coupon;
        }

        public void Execute()
        {
            _product.SetProductCoupon(_newCoupon);
        }

        public void Undo()
        {
            _product.SetProductCoupon(_previousCoupon);
        }
    }
}