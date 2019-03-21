using System;
using System.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;


namespace NRepository.RazorPages
{



    public class Program
    {
        public static void LocalLoggerSetup()
        {

            Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Debug()
      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
         //   .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Debug)
      .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
      .Enrich.FromLogContext()
      .WriteTo.Console()
  // Add this line:
  .WriteTo.File(
      @"c:\Logs\myapp.txt",
  fileSizeLimitBytes: 1_000_000,
  rollOnFileSizeLimit: true,
  shared: true,
  flushToDiskInterval: TimeSpan.FromSeconds(1))
   .WriteTo.RollingFile(@"c:\Logs\myappRolling.txt", LogEventLevel.Verbose,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}.{Method}) {Message}{NewLine}{Exception}")
        // .WriteTo.RollingFile(Configuration.GetValue<string>("LogFilePath") + "-{Date}.txt", LogEventLevel.Information,
        //outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] ({SourceContext}.{Method}) {Message}{NewLine}{Exception}")
    .CreateLogger();

        }

        // this is just for testing
        public static int ViewStartCallCounter = 0;
        public static void Main(string[] args)
        {
            Console.Title = "IdServer";

            LocalLoggerSetup();
            //LoggerNewSetup.SetupIdentityServer4GlobalServerLogging();
            //   LoggerConfig.Setup();
            Log.Information("Starting the Log");
            Log.Warning("Starting the Log");
            Log.Error("Starting the Log");
            IWebHost host = CreateWebHostBuilder(args).Build();
            try
            {
                EvitiContact.Application.ApplicationSetup.SetupApp(host.Services);

                host.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

            }
            finally
            {
                try
                {
                    Log.Warning("Stopping web host - in Finally");
                    Log.CloseAndFlush();
                }
                catch (Exception)
                {


                }

            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

                .UseStartup<Startup>()
            .UseSerilog(); // <-- Add this line 
    }
}
