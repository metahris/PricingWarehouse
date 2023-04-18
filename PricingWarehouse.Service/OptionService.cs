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
        public static IList<IOption> ComputeDelta(IPriceable<IOption> priceable, IDependencyInjector dependencyInjector)
        {
            var marketData = priceable.MarketData;
            var deltaResults = new List<IOption>();
            var objectSerializer = dependencyInjector.Resolve<IObjectSerializer>();
            Parallel.ForEach(priceable.Products, option =>
            {
                var pricingService = dependencyInjector.Resolve<IPricingService<IProduct>>(option.PricingModel.ToString());

                var underlyingPrice = option.GetUnderlyingPrice();
                double h = underlyingPrice * 0.0001; // small step size for finite difference approximation
               
                var optionUp = objectSerializer.Clone(option);
                optionUp.SetUnderlyingPrice(underlyingPrice + h);

                var optionDown = objectSerializer.Clone(option);
                optionDown.SetUnderlyingPrice(underlyingPrice - h);

                double delta = (pricingService.Price(optionUp, marketData) - pricingService.Price(optionDown, marketData)) / 2*h;
                option.SetDelta(delta);
                lock (deltaResults) // lock to safely add delta results to the list
                {
                    deltaResults.Add(option);
                }
            });
            return deltaResults;
        }

        public static IList<IOption> ComputeGamma(IPriceable<IOption> priceable, IDependencyInjector dependencyInjector)
        {
            var marketData = priceable.MarketData;
            var gammaResults = new List<IOption>();
            var objectSerializer = dependencyInjector.Resolve<IObjectSerializer>();
            Parallel.ForEach(priceable.Products, option =>
            {
                var pricingService = dependencyInjector.Resolve<IPricingService<IProduct>>(option.PricingModel.ToString());

                var underlyingPrice = option.GetUnderlyingPrice();
                double h = underlyingPrice * 0.0001; // small step size for finite difference approximation

                var optionUp = objectSerializer.Clone(option);
                optionUp.SetUnderlyingPrice(underlyingPrice + h);

                var optionDown = objectSerializer.Clone(option);
                optionDown.SetUnderlyingPrice(underlyingPrice - h);

                double gamma = (pricingService.Price(optionUp, marketData) - 2 * pricingService.Price(option, marketData) + pricingService.Price(optionDown, marketData)) / Math.Pow(h, 2);
                option.SetGamma(gamma);
                lock (gammaResults) // lock to safely add gamma results to the list
                {
                    gammaResults.Add(option);
                }
            });
            return gammaResults;
        }

    }
}
