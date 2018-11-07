﻿using Microsoft.EntityFrameworkCore;
using NRepository.MyTestBL.BL;
using NRepository.MyTestBL.BL.DataAccess;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NRepository.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<ITestRepository, TestRepository>();
            container.Register<TestProvider>();
            container.Register<DbContext, MyTestContext>(Lifestyle.Scoped);
            container.Register<DbContextOptions<MyTestContext>>(() => {
                return new DbContextOptionsBuilder<MyTestContext>()
                .UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;")
                .Options;
            }, Lifestyle.Singleton);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
