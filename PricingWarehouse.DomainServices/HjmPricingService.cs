using PricingWarehouse.Domain;

namespace PricingWarehouse.DomainServices
{
    public class HjmPricingService : IPricingService<IOption>
    {
        public double Price(IOption option, IMarketData marketData)
        {
            throw new NotImplementedException();
        }
    }
}
