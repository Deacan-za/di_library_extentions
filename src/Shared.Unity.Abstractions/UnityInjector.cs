using Shared.Lib;
using Unity;
using Unity.Lifetime;

namespace Shared.Unity.Abstractions
{
    public class UnityInjector : IServiceInjector<IUnityContainer>
    {
        public void InjectServices(IUnityContainer container)
        {
            container.RegisterType<IService1, Service1>(new ContainerControlledTransientManager());
        }

    }
}
