using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WcfFrameWork.AOP
{
    public class LogHelper
    {
        private const string SError = "Error";
        private const string SDebug = "Debug";
        private const string DefaultName = "Info";

        static LogHelper()
        {
            //var path = HostingEnvironment.MapPath(@"~/Log4Net.config");
            var path = System.Environment.CurrentDirectory + "/Log4Net.config";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }

        public static log4net.ILog GetLog(string logName)
        {
            var log = log4net.LogManager.GetLogger(logName);
            return log;
        }

        public static void Debug(string message)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(SDebug);
                if (log.IsDebugEnabled)
                    log.Debug(message);
            });      
        }

        public static void Debug(string message, Exception ex)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(SDebug);
                if (log.IsDebugEnabled)
                    log.Debug(message, ex);
            });       
        }

        public static void Error(string message)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(SError);
                if (log.IsErrorEnabled)
                    log.Error(message);
            });           
        }

        public static void Error(string message, Exception ex)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(SError);
                if (log.IsErrorEnabled)
                    log.Error(message, ex);
            });           
        }

        public static void Fatal(string message)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(DefaultName);
                if (log.IsFatalEnabled)
                    log.Fatal(message);
            });          
        }

        public static void Info(string message)
        {
            Task.Run(() =>
            {
                log4net.ILog log = log4net.LogManager.GetLogger(DefaultName);
                if (log.IsInfoEnabled)
                    log.Info(message);
            });     
        }

        public static void Warn(string message)
        {
            Task.Run(() =>
            {
                var log = log4net.LogManager.GetLogger(DefaultName);
                if (log.IsWarnEnabled)
                    log.Warn(message);
            });      
        }
    }
}
