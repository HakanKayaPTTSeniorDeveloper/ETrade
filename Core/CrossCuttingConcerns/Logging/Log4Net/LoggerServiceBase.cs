using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public void Info(object logMessage, bool isNvi)
        {
            if (IsInfoEnabled)
            {
                LogicalThreadContext.Properties["isNvi"] = isNvi;
                _log.Info(logMessage);
            }

        }
        public void Debug(object logMessage, bool isNvi)
        {
            if (IsDebugEnabled)
            {
                LogicalThreadContext.Properties["isNvi"] = isNvi;
                _log.Debug(logMessage);
            }

        }
        public void Warn(object logMessage, bool isNvi)
        {
            if (IsWarnEnabled)
            {
                LogicalThreadContext.Properties["isNvi"] = isNvi;
                _log.Warn(logMessage);
            }

        }
        public void Fatal(object logMessage, bool isNvi)
        {
            if (IsFatalEnabled)
            {
                LogicalThreadContext.Properties["isNvi"] = isNvi;
                _log.Fatal(logMessage);
            }

        }
        public void Error(object logMessage, bool isNvi)
        {
            if (IsErrorEnabled)
            {
                LogicalThreadContext.Properties["isNvi"] = isNvi;
                _log.Error(logMessage);
            }

        }













    }
}