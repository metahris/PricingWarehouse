using PricingWarehouse.Domain;

namespace PricingWarehouse.DomainServices
{
    public interface IPricingService
    {
        double Price(IProduct product);

    }
}