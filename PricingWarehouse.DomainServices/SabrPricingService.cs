using PricingWarehouse.Domain;

namespace PricingWarehouse.DomainServices
{
    public class SabrPricingService : IPricingService<IOption>
    {
        public double Price(IOption option, IMarketData marketData)
        {
            throw new NotImplementedException();
        }

    }
}
