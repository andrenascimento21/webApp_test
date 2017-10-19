using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc5;

namespace WebApplication2.Utils
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //container.RegisterType<IService, FakeService>();
            //container.RegisterType<ILogger, FakeLogger>();
            //MvcUnityContainer.Container = container;
            return container;
        }
    }
}