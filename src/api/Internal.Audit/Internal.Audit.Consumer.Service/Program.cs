using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new ConsumerService()
            //};
            //ServiceBase.Run(ServicesToRun);


            Log.Logger = new LoggerConfiguration()              
               .WriteTo.File(ConfigurationManager.AppSettings["log.file"], rollingInterval: RollingInterval.Day)             
               .CreateLogger();
            Log.Fatal("test", "Something went wrong, application failed to start!");
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new ConsumerService() };
                ServiceBase.Run(ServicesToRun);


                //var cc = new ConsumerService();
                //cc.Consume();
                //Console.ReadKey(true);


                //if (System.Environment.UserInteractive)
                //{

                //    if (args.Any())
                //    {
                //        switch (args[0])
                //        {

                //            case "-install":
                //                InstallHelper.InstallHelper.InstallService();
                //                InstallHelper.InstallHelper.StartService();
                //                break;
                //            case "-uninstall":
                //                InstallHelper.InstallHelper.StopService();
                //                InstallHelper.InstallHelper.UninstallService();
                //                break;
                //            default:
                //                throw new NotImplementedException();
                //        }
                //    }
                //}
                //else
                //{
                //    ServiceBase[] ServicesToRun;
                //    ServicesToRun = new ServiceBase[] { new ConsumerService() };
                //    ServiceBase.Run(ServicesToRun);
                //}
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Something went wrong, application failed to start!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
