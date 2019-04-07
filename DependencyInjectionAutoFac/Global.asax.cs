using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DependencyInjectionAutoFac
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Registering the dependencies of AutoFac
            var builder = new ContainerBuilder();

            //Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            //Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            //Register our data dependencies
            builder.RegisterModule(new DataModule("DependencyInjectionAutoFacContext"));

            var container = builder.Build();

            //Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
