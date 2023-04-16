using PricingWarehouse.Domain;

namespace PricingWarehouse.Repository
{
    public interface IProductRepository<T> where T : IProduct
    {
        int InsertProduct(T product);
        T GetProductById(int productId);
    }
}
