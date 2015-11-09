using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Log
{
    public class Log4NetLogger:ILogger
    {

        public  Log4NetLogger()
        {
            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            LoadConfiguration();
        }

        /// <summary>
        /// 加载log4net配置
        /// </summary>
        private static void LoadConfiguration()
        {

            FileInfo info = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/Log4Net.config"));
            if (info.Exists)
            {
                log4net.Config.XmlConfigurator.Configure(info);
            }
            else
            {
                log4net.Config.XmlConfigurator.Configure();
            }

        }

        private ILog _logger = null;

        internal Log4NetLogger(Type type)
        {
            _logger = log4net.LogManager.GetLogger(type);
        }

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Information:
                    return _logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return _logger.IsWarnEnabled;
                case LogLevel.Debug:
                    return _logger.IsDebugEnabled;
                case LogLevel.Error:
                    return _logger.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _logger.IsFatalEnabled;
                default: return false;
            }
        }

        public void Log(LogLevel level, Exception exception, string format = null, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Information:
                    _logger.Info(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Warning:
                    _logger.Warn(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Error:
                    _logger.Error(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Fatal:
                    _logger.Fatal(args == null ? format : string.Format(format, args), exception);
                    break;

            }
        }
    }
}
