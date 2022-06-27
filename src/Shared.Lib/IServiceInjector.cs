using Unity;

namespace Shared.Lib
{
  public interface IServiceInjector
  {
    void InjectServices(IUnityContainer container);
  }
}