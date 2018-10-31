using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TestAutoFacLib;
using TestAutoFacMvc.Controllers;

namespace TestAutoFacMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            //            builder.RegisterType<HomeController>().UsingConstructor

            //var hc = new HomeController();
            //builder.RegisterInstance(hc).As<Controller>();

            //自己释放对象
            //builder.RegisterInstance(hc).As<Controller>().ExternallyOwned();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(typeof(MvcApplication).Assembly); 
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
