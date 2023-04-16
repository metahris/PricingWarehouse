using PricingWarehouse.Domain;

namespace PricingWarehouse.DomainServices
{
    public interface IPricingService<T> where T : IProduct
    {
        double Price(T product, IMarketData marketData);

    }
}