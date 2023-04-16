namespace PricingWarehouse.Domain
{
    public interface IProduct
    {
        int Id { get; }
        Price Price { get; }
        void SetId(int id);
        void SetPrice(double price);
    }
}
