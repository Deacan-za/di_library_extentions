
using System;
using System.Linq;
using System.Reflection;
using Unity;

namespace Shared.Lib
{
  public static class UnityExtensions
  {
    public static void AddSharedServices(this IUnityContainer container, Action<SharedConfig>? configuration = null)
    {
      container.Configure(configuration);

      AddServicesFromAssembliesContaining(container, typeof(ISharedAssemblyMarker));
    }

    private static void AddServicesFromAssembliesContaining(this IUnityContainer container, params Type[] assemblyMarkers)
    {
      var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
      AddServicesFromAssemblies(container, assemblies);
    }

    private static void AddServicesFromAssemblies(this IUnityContainer container, params Assembly[] assemblies)
    {
      foreach (var assembly in assemblies)
      {
        var installerType = assembly.DefinedTypes.Where(x =>
          typeof(IServiceInjector).IsAssignableFrom(x)
          && !x.IsInterface
          && !x.IsAbstract);

        var installers = installerType.Select(Activator.CreateInstance).Cast<IServiceInjector>();

        foreach (var installer in installers)
        {
          installer.InjectServices(container);
        }
      }
    }

    private static void Configure(this IUnityContainer container, Action<SharedConfig>? configuration = null)
    {
      var options = new SharedConfig();
      configuration?.Invoke(options);

      container.RegisterInstance(typeof(SharedConfig), options);

    }
  }
}