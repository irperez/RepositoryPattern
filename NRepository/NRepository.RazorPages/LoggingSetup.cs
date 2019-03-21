using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Configuration;

namespace NRepository.RazorPages
{
    public class LoggingStartupOptions
    {

        /// <summary>
        /// The name of of the application connect, eviti advisor
        /// </summary>
        public string ApplicatonName { get; set; }
        /// <summary>
        /// The name of the specific Environment Waltham Staging, Beta3QA, VM-Test3.. 
        /// </summary>
        public string EnvironmentName { get; set; }

        public string RunningDirectory { get; set; }

        public static LoggingStartupOptions GetItem()
        {
            LoggingStartupOptions result = new LoggingStartupOptions();

            string EnvironmentName = ConfigurationManager.AppSettings["EnvironmentName"];
            string appName = ConfigurationManager.AppSettings["IDServerApplicationManager.ApplicationName"];

            if (string.IsNullOrWhiteSpace(EnvironmentName))
            {
                EnvironmentName = "EnvironmentNameNotSet";
            }
            if (string.IsNullOrWhiteSpace(appName))
            {
                appName = "appNameNotSet";
            }
            result.EnvironmentName = EnvironmentName;
            result.ApplicatonName = appName;
            result.RunningDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return result;
        }
    }

    public class LoggingPaths
    {
        public const string TxtExt = @".txt";
        public const string JsonExt = @".json";
        public const string LogFileName = "Log";
        public static string GetAppLoggingPath(bool IsJson)
        {
            var appdetails = LoggingStartupOptions.GetItem();

            return GetLoggingPath(appdetails.EnvironmentName, appdetails.ApplicatonName, LogFileName, IsJson);
        }

        private static void ValidateNames(string EnvornmentName, string ApplicatonName)
        {
            if (string.IsNullOrWhiteSpace(ApplicatonName))
            {
                throw new System.ApplicationException("ApplicatonName is required");
            }
            if (string.IsNullOrWhiteSpace(EnvornmentName))
            {
                throw new System.ApplicationException("EnvornmentName is required");
            }
        }

        public static string GetLoggingPath(string EnvornmentName, string ApplicatonName, string LogFileName, bool IsJson)
        {
            ValidateNames(EnvornmentName, ApplicatonName);

            string ext = TxtExt;
            if (IsJson)
            {
                ext = JsonExt;
            }

            return @"c:\logs\serilog\" + EnvornmentName + @"\" + ApplicatonName + @"\" + LogFileName + ext;

        }

    }
    public class ConfigurationUtility
    {
        public const string EnvironmentKey = "Environment";
        public const string EnvironmentNameKey = "EnvironmentName";
        public const string ApplicationNameKey = "Application.Name";

        public static string Environment()
        {
            return ConfigurationManager.AppSettings[EnvironmentKey];
        }

        public static string EnvironmentName()
        {
            return ConfigurationManager.AppSettings[EnvironmentNameKey];
        }
        public static string ApplicationName()
        {
            return ConfigurationManager.AppSettings[ApplicationNameKey];
        }

        public static bool IsDevelopmentEnvironment()
        {
            if (ConfigurationManager.AppSettings[EnvironmentKey]?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }

            return false;
        }

        public static bool IsTestEnvironment()
        {
            if (ConfigurationManager.AppSettings[EnvironmentKey]?.Equals("Test", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }

            return false;
        }

        public static bool IsStagingEnvironment()
        {
            if (ConfigurationManager.AppSettings[EnvironmentKey]?.Equals("Staging", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }

            return false;
        }

        public static bool IsProductionEnvironment()
        {
            if (ConfigurationManager.AppSettings[EnvironmentKey]?.Equals("PRODUCTION", StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }

            return false;
        }
    }
    public class LoggerNewSetup
    {
        public static LogEventLevel GetGlobalLogLevel()
        {
            LogEventLevel logEventLevel = GetLogEventLevelFromConfig("Serilog.GlobalLogEventLevel");
            return logEventLevel;
        }

        public static LogEventLevel GetMicrosoftLogLevel()
        {
            LogEventLevel logEventLevel = GetLogEventLevelFromConfig("Serilog.MicrosoftLogEventLevel");
            return logEventLevel;

        }
        public static bool IsLoggingDisabled()
        {
            bool IsDisabled = false;
            try
            {
                IsDisabled = Convert.ToBoolean(ConfigurationManager.AppSettings["Serilog.IsLoggingDisabled"]);

            }
            catch (Exception)
            {

            }

            return IsDisabled;

        }




        public static LogEventLevel GetLogEventLevelFromConfig(string key)
        {
            LogEventLevel SerilogLogLevel = LogEventLevel.Warning;

            try
            {
                string TempSerilogLogLevel = ConfigurationManager.AppSettings[key];

                if (string.IsNullOrWhiteSpace(TempSerilogLogLevel) == false)
                {
                    //Verbose=0,Debug=1,Information=2,Warning=3,Error=4,Fatal=5
                    int temp1 = Convert.ToInt32(TempSerilogLogLevel);
                    SerilogLogLevel = (LogEventLevel)temp1;
                }

            }
            catch (Exception)
            {
                SerilogLogLevel = LogEventLevel.Warning;
            }

            return SerilogLogLevel;
        }



        public static string SEQServer = "http://deviq-02:5341";
        public static LoggingLevelSwitch SeqLogLevelSwitch = new LoggingLevelSwitch();

        public static void SetupIdentityServer4GlobalServerLogging()
        {


            string logfileName = LoggingPaths.GetAppLoggingPath(false);

            logfileName = @"c:\logs\Log.txt";

            // See this for help reading from the config file.
            //serilog-extensions-logging-file - Add file logging to ASP.NET Core apps in one line of code. 
            //https://github.com/serilog/serilog-extensions-logging-file/blob/dev/example/WebApplication/Program.cs
            //https://github.com/serilog/serilog-extensions-logging-file
            SeqLogLevelSwitch.MinimumLevel = LogEventLevel.Information;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                //.MinimumLevel.Override("System", LogEventLevel.Warning)
                //.MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(logfileName, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10))
                //.WriteTo.Seq(LoggerNewSetup.SEQServer, controlLevelSwitch: SeqLogLevelSwitch)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
                .CreateLogger();

            return;
        }

        public static void StopLogging()
        {
            Log.CloseAndFlush();
        }
    }
    public class LoggerConfig
    {
        public static LoggingLevelSwitch GlobalLogLevelSwitch = new LoggingLevelSwitch();
        public static LoggingLevelSwitch MicrosoftLogLevelSwitch = new LoggingLevelSwitch();
        public static void Setup()
        {
            if (LoggerNewSetup.IsLoggingDisabled())
            { return; }
            GlobalLogLevelSwitch.MinimumLevel = LoggerNewSetup.GetGlobalLogLevel();
            MicrosoftLogLevelSwitch.MinimumLevel = LoggerNewSetup.GetMicrosoftLogLevel();

            string logfileName = LoggingPaths.GetAppLoggingPath(false);
            string logfileNameJson = LoggingPaths.GetAppLoggingPath(true);
            var appdetails = LoggingStartupOptions.GetItem();
            string IDServerRenderedCompactJsonFormatterLogFileName = LoggingPaths.GetLoggingPath(appdetails.EnvironmentName, appdetails.ApplicatonName, "IDServerRenderedCompactJsonFormatter", true);

            var serilogConfiguration = new LoggerConfiguration();

            serilogConfiguration.MinimumLevel.ControlledBy(GlobalLogLevelSwitch)
            .MinimumLevel.Override("Microsoft", MicrosoftLogLevelSwitch)
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //.MinimumLevel.Override("System", LogEventLevel.Warning)
            //.MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .Enrich.FromLogContext()
            // .Enrich.WithMachineName()
            .Enrich.WithProperty("App Name", "IdServer");

            if (ConfigurationUtility.IsDevelopmentEnvironment())
            {
                serilogConfiguration.WriteTo.Console();
                serilogConfiguration.WriteTo.Debug();
            }
            if (ConfigurationUtility.IsDevelopmentEnvironment())
            {
                serilogConfiguration.WriteTo.File(new CompactJsonFormatter(), logfileNameJson, rollingInterval: RollingInterval.Day, buffered: false);
            }
            if (ConfigurationUtility.IsDevelopmentEnvironment())
            {
                serilogConfiguration.WriteTo.File(new RenderedCompactJsonFormatter(), IDServerRenderedCompactJsonFormatterLogFileName, rollingInterval: RollingInterval.Day, buffered: false);
            }
            serilogConfiguration.WriteTo.File(logfileName, rollingInterval: RollingInterval.Day, buffered: false);


            Log.Logger = serilogConfiguration.CreateLogger();

            AppDomain.CurrentDomain.DomainUnload += (o, e) =>
            {
                Log.Warning("Stopping web host - in DomainUnload");
                Log.CloseAndFlush();
            };
        }

        //public static void OLDSetup()
        //{


        //    GlobalLogLevelSwitch.MinimumLevel = LoggerNewSetup.GetLogEventLevelFromConfig("Serilog.GlobalLogEventLevel");
        //    MicrosoftLogLevelSwitch.MinimumLevel = LoggerNewSetup.GetLogEventLevelFromConfig("Serilog.MicrosoftLogEventLevel");

        //    var appdetails = LoggingStartupOptions.GetItem();
        //    string IDServerCompactJsonFormatter = LoggingPaths.GetLoggingPath(appdetails.EnvironmentName, appdetails.ApplicatonName, "IDServerCompactJsonFormatter", true);
        //    string RenderedCompactJsonFormatter = LoggingPaths.GetLoggingPath(appdetails.EnvironmentName, appdetails.ApplicatonName, "RenderedCompactJsonFormatter", true);
        //    string t = string.Empty;

        //    //Log.Logger = new LoggerConfiguration()
        //    //  .ReadFrom.Configuration(Configuration)
        //    //  .Enrich.FromLogContext()
        //    //  .WriteTo.Console()
        //    //  .CreateLogger();

        //    //Log.Logger = serilogConfiguration.CreateLogger();

        //    //http://blog.devbot.net/logging-practices/

        //    var serilogConfiguration = new LoggerConfiguration()
        //        .MinimumLevel.ControlledBy(GlobalLogLevelSwitch)
        //       .MinimumLevel.Override("Microsoft", MicrosoftLogLevelSwitch)
        //       //.MinimumLevel.Override("System", LogEventLevel.Warning)
        //       //.MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
        //       .Enrich.FromLogContext()
        //       // .Enrich.WithMachineName()
        //       .Enrich.WithProperty("App Name", "IdServer");
        //    // .WriteTo.File(new RenderedCompactJsonFormatter(), RenderedCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10))
        //    // .WriteTo.Console()
        //    //.WriteTo.File(new CompactJsonFormatter(), IDServerCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10));

        //    if (1 == 1)
        //    {
        //        serilogConfiguration.WriteTo.File(new RenderedCompactJsonFormatter(), RenderedCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10));
        //    }
        //    if (1 == 1)
        //    {
        //        serilogConfiguration.WriteTo.File(new CompactJsonFormatter(), IDServerCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10));
        //    }
        //    if (Environment.UserInteractive)
        //    {
        //        serilogConfiguration.WriteTo.Console();
        //    }


        //    Log.Logger = serilogConfiguration.CreateLogger();
        //    AppDomain.CurrentDomain.DomainUnload += (o, e) =>
        //    {
        //        Log.Warning("Stopping web host - in DomainUnload");
        //        Log.CloseAndFlush();
        //    };


        //    //Log.Logger = new LoggerConfiguration()
        //    //   .MinimumLevel.ControlledBy(GlobalLogLevelSwitch)
        //    //   .MinimumLevel.Override("Microsoft", MicrosoftLogLevelSwitch)
        //    //   //.MinimumLevel.Override("System", LogEventLevel.Warning)
        //    //   //.MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
        //    //   .Enrich.FromLogContext()
        //    //   // .Enrich.WithMachineName()
        //    //   .Enrich.WithProperty("App Name", "IdServer")
        //    //.WriteTo.File(new RenderedCompactJsonFormatter(), RenderedCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10))
        //    //.WriteTo.Console()

        //    //   .WriteTo.File(new CompactJsonFormatter(), IDServerCompactJsonFormatter, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(10))
        //    //   .CreateLogger();
        //}


    }
}
