using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Service;

namespace webApp_test
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}