using Unity;

namespace Shared.Lib
{
    public interface IServiceInjector<in T>
    {
        void InjectServices(T container);
    }
}