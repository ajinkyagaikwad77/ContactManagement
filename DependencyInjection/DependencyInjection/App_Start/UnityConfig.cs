using DAL;
using Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DependencyInjection
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IContactRespository, ContactRepository>();
            container.RegisterType<IContactService, ContactService>();
        }
    }
}