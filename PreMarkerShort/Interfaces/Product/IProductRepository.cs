using System.Collections.Generic;

namespace PreMarkerShort.Interfaces.Product
{
    public interface IRepository
    {
        IEnumerable<IProduct> GetAvailableProducts();
        IEnumerable<ICoupon> GetAvailableCoupons();

        void SaveProducts(IEnumerable<IProduct> products);
    }
}