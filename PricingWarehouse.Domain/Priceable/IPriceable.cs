namespace PricingWarehouse.Domain
{
    public interface IPriceable<T> where T : IProduct
    {
        IList<T> Products { get; }
        IMarketData MarketData { get; }

    }
}
