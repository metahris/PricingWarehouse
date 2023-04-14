using PricingWarehouse.DTO;

namespace PricingWarehouse.DAO
{
    public interface IProducDAO<T> where T : IProductDTO
    {
        int InsertProduct(T product);
        T GetProductById(int productId);
    }
}
