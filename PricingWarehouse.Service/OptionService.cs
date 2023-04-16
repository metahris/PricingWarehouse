using PricingWarehouse.Domain;
using PricingWarehouse.DomainServices;
using PricingWarehouse.Infrastructure;
using PricingWarehouse.Repository;

namespace PricingWarehouse.Service
{
    public class OptionService: IProductService<IOption>
    {
        private readonly IProductRepository<IOption> productRepository;

        public OptionService(IProductRepository<IOption> productRepository)
        {
            this.productRepository = productRepository;
        }
        public int PersistProduct(IOption option)
        {
            return this.productRepository.InsertProduct(option);
        }
        public IList<IOption> Price(IPriceable<IOption> priceable, IDependencyInjector dependencyInjector)
        {
            var marketData = priceable.MarketData;
            var pricingResults = new List<IOption>();
            Parallel.ForEach(priceable.Products, option =>
            {
                var pricingService = dependencyInjector.Resolve<IPricingService<IProduct>>(option.PricingModel.ToString());
                double price = pricingService.Price(option, marketData);
                option.SetPrice(price);
                lock (pricingResults) // lock to safely add pricing results to the list
                {
                    pricingResults.Add(option);
                }
            });
            return pricingResults;
        }
    }
}
