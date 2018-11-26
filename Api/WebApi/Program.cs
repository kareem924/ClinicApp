using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                var webHost = new WebHostBuilder().UseKestrel()
                                                  .UseContentRoot(Directory.GetCurrentDirectory())
                                                  .ConfigureAppConfiguration((hostingContext, config) =>
                                                  {
                                                      var env = hostingContext.HostingEnvironment;
                                                      config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                                                                optional: true, reloadOnChange: true);
                                                      config.AddEnvironmentVariables();
                                                  })
                                                  .ConfigureLogging((hostingContext, logging) =>
                                                  {
                                                      logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                                                      logging.AddConsole();
                                                      logging.AddDebug();
                                                      logging.AddEventSourceLogger();
                                                  })
                                                  .UseStartup<Startup>()
                                                  .UseNLog()
                                                  .Build();
                webHost.Run();


            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
