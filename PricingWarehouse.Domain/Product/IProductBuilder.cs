namespace PricingWarehouse.Domain
{
    public interface IProductBuilder<T> where T : IProduct
    {
        T Build();
    }
}
