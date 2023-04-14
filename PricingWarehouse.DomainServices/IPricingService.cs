using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.DomainServices
{
    public interface IPricingService
    {
        double Price(IProduct product);

    }
}