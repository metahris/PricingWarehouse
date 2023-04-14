namespace PricingWarehouse.Domain
{
    public interface IPriceable
    {
        List<IProduct> Products { get; }
        IMarketData MarketData { get; }

    }
    public class Priceable : IPriceable
    {
        public List<IProduct> Products { get; private set; }
        public IMarketData MarketData { get; private set; }
        public Priceable(List<IProduct> products, IMarketData marketData)
        {
            Products = products;
            MarketData = marketData;
        }
    }
}
