namespace PreMarkerShort.Interfaces.Cart 
{                       
    public interface ICartCouponCommandFactory
    {
        ICommand CreateSetCartCouponCommand(IProductCart cart, ICartCoupon cartCoupon);
    }
}