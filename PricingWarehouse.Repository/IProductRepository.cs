using PricingWarehouse.Domain.IRSwap;
using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.Repository
{
    public interface IProductRepository<T> where T : IProduct
    {
        int InsertProduct(T product);
        T GetProductById(int productId);
    }
 
}
