using EvitiContact.SchoolModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;   // CreateScope
using Microsoft.Extensions.Logging;
using System;

namespace EvitiContact.Service.SchoolModelDB
{
    public class SchoolModelDbContextSetupDB
    {
        public static void Setup(IWebHost host)
        {

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<SchoolModelDbContext>();
                
                    context.Database.Migrate();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<SchoolModelDbContextSetupDB>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}
