using PricingWarehouse.Domain;
using PricingWarehouse.DomainServices;
using PricingWarehouse.Infrastructure;
using PricingWarehouse.Repository;
using PricingWarehouse.Service;

namespace PricingWarehouse.NETMQService
{
    public class NETMQServiceRegistration
    {
        public static void Build(IDependencyInjector dependencyInjector)
        {
            dependencyInjector.Register<IObjectSerializer, ObjectSerializer>();
            dependencyInjector.Register<IOption, EuropeanSwaption>();
            dependencyInjector.Register<IProductRepository<EuropeanSwaption>, EuropeanSwaptionRepository>();
            dependencyInjector.Register<IProductService<IOption>, OptionService>();
            dependencyInjector.Register<IPricingService<IOption>, SabrPricingService>(PricingModel.Sabr.ToString());
            dependencyInjector.Register<IPricingService<IOption>, HestonPricingService>(PricingModel.Heston.ToString());
            dependencyInjector.Register<IPricingService<IOption>, HjmPricingService>(PricingModel.Hjm.ToString());
            dependencyInjector.Register<IProductBuilder<EuropeanSwaption>, EuropeanSwaptionBuilder>();

        }

    }
}
