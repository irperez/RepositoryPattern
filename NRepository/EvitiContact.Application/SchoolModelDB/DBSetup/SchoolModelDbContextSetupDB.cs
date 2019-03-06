using System;
using EvitiContact.SchoolModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;   // CreateScope
using Microsoft.Extensions.Logging;

namespace EvitiContact.ApplicationService.SchoolModelDB.DBSetup
{
    public class SchoolModelDbContextSetupDB
    {
        //public static void Setup(IWebHost host)
        //{

        //   using (var scope = host.Services.CreateScope())


        public static void Setup(IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
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
