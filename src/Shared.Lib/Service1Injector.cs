using Unity;
using Unity.Lifetime;

namespace Shared.Lib
{
  public class Service1Injector : IServiceInjector
  {
    public void InjectServices(IUnityContainer container)
    {
      container.RegisterType<IService1, Service1>(new ContainerControlledTransientManager());
    }
  }
}