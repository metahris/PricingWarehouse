using DryIoc;
namespace PricingWarehouse.Infrastructure
{
    public interface IDependencyInjector
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void Register<TInterface, TImplementation>(string key) where TImplementation : TInterface;
        T Resolve<T>();
        T Resolve<T>(string key);
    }
    public class DependencyInjector : IDependencyInjector
    {
        private readonly IContainer container;

        public DependencyInjector()
        {
            container = new Container();
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            container.Register<TInterface, TImplementation>();
        }
        public void Register<TInterface, TImplementation>(string key) where TImplementation : TInterface
        {
            container.Register<TInterface, TImplementation>(serviceKey: key);
        }
        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        public T Resolve<T>(string key)
        {
            return container.Resolve<T>(serviceKey: key);
        }
    }
}
