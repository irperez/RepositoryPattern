using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NRepository.RazorPages
{
    public class Program
    {

        // this is just for testing
        public static int ViewStartCallCounter = 0;
        public static void Main(string[] args)
        {

            IWebHost host = CreateWebHostBuilder(args).Build();

            EvitiContact.Application.ApplicationSetup.SetupApp(host.Services);
       
            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
