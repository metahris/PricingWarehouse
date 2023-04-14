using PricingWarehouse.Domain.Product;
using PricingWarehouse.Domain.MarketData;
namespace PricingWarehouse.Domain.Priceable
{
    public interface IPriceable
    {
        List<IProduct> Products { get; }
        IMarketData MarketData { get; }

    }
}
