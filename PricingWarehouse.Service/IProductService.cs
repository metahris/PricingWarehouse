using PricingWarehouse.Domain;
using PricingWarehouse.Infrastructure;

namespace PricingWarehouse.Service
{
    public interface IProductService<T> where T: IProduct
    {
        int PersistProduct(T product);
        IList<T> Price(IPriceable<T> priceable, IDependencyInjector dependencyInjector);
    }
}