using Autofac;
using DemoLibrary;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
  public static class ContainerConfig
  {
    public static IContainer Configure()
    {

      var builder = new ContainerBuilder();

      #region Manual Builders
      // menual setup
      //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
      builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();
      builder.RegisterType<Application>().As<IApplication>();
      #endregion

      #region Auto Builders
      // auto configuration based on assembly name and namespace. You need to have Interface for all the classes
      builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
        .Where(t => t.Namespace.Contains("Utilities"))
        .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
      #endregion

      return builder.Build();
    }
  }
}
