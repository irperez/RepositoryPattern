using System.Reflection;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using eviti.data.tracking;
using eviti.data.tracking.DIHelp;
using eviti.data.tracking.PrincipalAccessor;
using EvitiContact.ApplicationService.ContactModelDB.Repository;
using EvitiContact.ApplicationService.ContactModelDB.Services;
using EvitiContact.ApplicationService.Services;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModel.Repository;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Domain.Services;
using EvitiContact.SchoolModel;
using EvitiContact.Service;
using EvitiContact.Service.Events;
using EvitiContact.Service.RepositoryDB;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NRepository.RazorPages.Infrastructure;
using NRepository.UniversityBL.BL;
using University.Data;


namespace NRepository.RazorPages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<UniversityBL.BL.ICourseRepository, UniversityBL.BL.CourseRepository>();
            services.AddScoped<CourseProvider>();

            var connectionString = Configuration.GetConnectionString("UniversityDB");
            services.AddDbContext<DbContext, UniversityContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<UniversityBL.BL.ICourseRepository, UniversityBL.BL.CourseRepository>();







            services.AddAutoMapper(cfg =>
            {
                // this is need to map existing collection to existing collections.  Otherwise for some reason auto mapper  
                // will remove and replace the collections. 
                //http://docs.automapper.org/en/stable/Lists-and-arrays.html
                //https://github.com/AutoMapper/AutoMapper.Collection/blob/master/README.md
                cfg.AddCollectionMappers();

                // this package is only in v0.1 Install-Package AutoMapper.Collection.EntityFramework
                // so for now we need to manually add the mappings
                //cfg.SetGeneratePropertyMaps<GenerateEntityFrameworkPrimaryKeyPropertyMaps<DB>>();
                // this will trigger a scan of the MDMasterProfile assembly
                cfg.AddProfiles(typeof(MDMasterProfile));
            });


            string evitiContactModelconnectionString = Configuration.GetConnectionString("UniversityDB");


            // services.AddDbContext<ContactModelDbContext>(options => options.UseInMemoryDatabase("ContactModelDbContext"));


            services.AddDbContext< ContactModelDbContext>(options =>
                options.UseSqlServer(evitiContactModelconnectionString));

            services.AddDbContext<SchoolModelDbContext>(options =>
                options.UseSqlServer(evitiContactModelconnectionString));


            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorPageFilter));  // global model state validation and respond with a json message of validation failures
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //   .AddJsonOptions(
            //    options => options.SerializerSettings.ReferenceLoopHandling =
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //) 

            // .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ContactAddressValidator>());  
            .AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<ContactPayerViewModel>()
            );

            services.AddScoped<MasterDetailControllerService>();
            services.AddScoped<MasterDetailControllerServiceNOSerlication>();

            services.AddScoped<IUnitOfWorkContactAndShoool, UnitOfWorkContactAndShoool>();

            services.AddTransient<MapAndSerializeGeneric>();
            services.AddTransient<IPrincipalAccessor, AspNetCorePrincipalAccessor>();

            //var t = AuditNotification.abc;


            services.AddMediatR(Assembly.GetExecutingAssembly(),
                typeof(Pong2).Assembly);

            //This will add the following behaviors to Mediator PipeLine.  I am just testing this as of yet 
            services.AddScoped(
                  typeof(IPipelineBehavior<,>),
                  typeof(ValidationBehavior<,>));
            //services.AddScoped(
            //    typeof(IPipelineBehavior<,>),
            //    typeof(TransactionBehavior<,>));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            services.AddSingleton<ServiceLocatorV2>();


            // Did not know that we could do this by just adding singletons to asp.net DI container
            var config = new Config(3); // Deserialize from appsettings.json
            services.AddSingleton(config);
            var commandsConnectionString = new CommandsConnectionString(evitiContactModelconnectionString);
            var queriesConnectionString = new QueriesConnectionString(evitiContactModelconnectionString);
            services.AddSingleton(commandsConnectionString);
            services.AddSingleton(queriesConnectionString);


            services.AddSingleton<IStateService, StateService>();
            services.AddTransient<IMyTestService, MyTestService>();
            services.AddTransient<Common.IDateService, Common.DateService>();
            services.AddTransient<IContactTypeRepository,  ContactTypeReposatory>();
            



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
            eviti.data.tracking.DIHelp.ServiceLocator.AppServiceProvider = ((ServiceProvider)app.ApplicationServices);
        }
    }
}
