using Microsoft.Extensions.DependencyInjection;
using Shared.Lib;
using System;
using System.Linq;
using System.Reflection;

namespace Shared.ServiceCollection.Abstractions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSharedServices(this IServiceCollection services,
            Action<SharedConfig> configuration = null)
        {
            services.Configure(configuration);

            AddServicesFromAssembliesContaining(services, typeof(ISharedAssemblyMarker));
        }

        private static void AddServicesFromAssembliesContaining(this IServiceCollection services, params Type[] assemblyMarkers)
        {
            var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
            AddServicesFromAssemblies(services, assemblies);
        }

        private static void AddServicesFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var installerType = assembly.DefinedTypes.Where(x =>
                    typeof(IServiceInjector<IServiceCollection>).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract);

                var installers = installerType.Select(Activator.CreateInstance).Cast<IServiceInjector<IServiceCollection>>();

                foreach (var installer in installers)
                {
                    installer.InjectServices(services);
                }
            }
        }

        private static void Configure(this IServiceCollection services, Action<SharedConfig> configuration = null)
        {
            var options = new SharedConfig();
            configuration?.Invoke(options);

            services.AddSingleton(typeof(SharedConfig), options);

        }
    }
}
