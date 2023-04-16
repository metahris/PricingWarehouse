namespace PricingWarehouse.Domain
{
    public class OptionPriceable:IPriceable<IOption>
    {
        public IList<IOption> Products { get; private set; }
        public IMarketData MarketData { get; private set; }
        public OptionPriceable(IList<IOption> options, IMarketData marketData)
        {
            Products = options;
            MarketData = marketData;
        }
    }
}
