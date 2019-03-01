using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.SchoolModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;   // CreateScope
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace EvitiContact.Service.ContactModelDB
{
    public class ContactModelDBSetupDB
    {
        public static void Setup(IWebHost host)
        {
          
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ContactModelDbContext>();
                    var mapper = services.GetRequiredService<IMapper>();
                    var env = services.GetRequiredService<IHostingEnvironment>();
                    var test = env.ContentRootPath;
                    var test2 = Directory.GetCurrentDirectory();
                    var test3 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    // using ContosoUniversity.Data; 
                    context.Database.Migrate();
                    DbInitializer.Initialize(context, mapper);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<ContactModelDBSetupDB>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}
