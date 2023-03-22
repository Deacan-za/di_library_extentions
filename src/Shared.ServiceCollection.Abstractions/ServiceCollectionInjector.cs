using Microsoft.Extensions.DependencyInjection;
using Shared.Lib;

namespace Shared.ServiceCollection.Abstractions
{
    public sealed class ServiceCollectionInjector : IServiceInjector<IServiceCollection>
    {
        public void InjectServices(IServiceCollection container)
        {
            container.AddSingleton<IService1, Service1>();
        }
    }
}
