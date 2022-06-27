
using System.Web.Http;
using Shared.Lib;
using Unity;
using Unity.WebApi;

namespace Test.API
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();
      container.AddSharedServices(config =>
      {
        config.InputValue = "This is a configuration string";
        config.ProductId = 5002;
      });


      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}