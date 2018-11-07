using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.Web;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Compilation;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using NRepository.MyTestBL.BL;
using NRepository.MyTestBL.BL.DataAccess;
using Microsoft.EntityFrameworkCore;

[assembly: PreApplicationStartMethod(typeof(NRepository.WebForms.PageInitializerModule), "Initialize")]
namespace NRepository.WebForms
{
    public sealed class PageInitializerModule : IHttpModule
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(PageInitializerModule));
        }

        void IHttpModule.Init(HttpApplication app)
        {
            app.PreRequestHandlerExecute += (sender, e) => {
                var handler = app.Context.CurrentHandler;
                if(handler != null)
                {
                    string name = handler.GetType().Assembly.FullName;
                    if(!name.StartsWith("System.Web") &&
                        !name.StartsWith("Microsoft"))
                    {
                        Global.InitializeHandler(handler);
                    }
                }
            };
        }

        void IHttpModule.Dispose() { }
    }
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Bootstrap();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static Container container;

        public static void InitializeHandler(IHttpHandler handler)
        {
            container.GetRegistration(handler.GetType(), true).Registration
                .InitializeInstance(handler);
        }

        private static void Bootstrap()
        {
            // 1. Create a new Simple Injector container.
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register a custom PropertySelectionBehavior to enable property injection.
            container.Options.PropertySelectionBehavior = new ImportAttributePropertySelectionBehavior();

            // 2. Configure the container (register)
            container.Register<ITestRepository, TestRepository>();
            container.Register<TestProvider>();
            container.Register<DbContext, MyTestContext>();
            container.Register<DbContextOptions<MyTestContext>>(() => {
                return new DbContextOptionsBuilder<MyTestContext>()
                .UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;")
                .Options;
            }, Lifestyle.Singleton);            

            // Register your Page classes to allow them to be verified and diagnosed.
            RegisterWebPages(container);

            Registration registration = container.GetRegistration(typeof(MyTestContext)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Reason of suppression");

            // 3. Store the container for use by Page classes.
            Global.container = container;

            // 3. Verify the container's configuration.
            container.Verify();
        }

        private static void RegisterWebPages(Container container)
        {
            var pageTypes =
                from assembly in BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                where !assembly.IsDynamic
                where !assembly.GlobalAssemblyCache
                from type in assembly.GetExportedTypes()
                where type.IsSubclassOf(typeof(Page))
                where !type.IsAbstract && !type.IsGenericType
                select type;

            foreach(Type type in pageTypes)
            {
                var reg = Lifestyle.Transient.CreateRegistration(type, container);
                reg.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "ASP.NET creates and disposes page classes for us.");
                container.AddRegistration(type, reg);
            }
        }

        class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
        {
            public bool SelectProperty(Type implementationType, PropertyInfo property)
            {
                // Makes use of the System.ComponentModel.Composition assembly
                return typeof(Page).IsAssignableFrom(implementationType) &&
                    property.GetCustomAttributes(typeof(ImportAttribute), true).Any();
            }
        }
    }
}