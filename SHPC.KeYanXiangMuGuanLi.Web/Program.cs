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

namespace SHPC.KeYanXiangMuGuanLi.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {

                logger.Debug("init main");
                BuildWebHost(args).Run();

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); 
                 })
                 .UseNLog()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseWebRoot(Directory.GetCurrentDirectory() + "/wwwroot")
                 .UseIISIntegration()
                 .UseUrls("http://localhost:5016/")
                 .Build();
    }
}
