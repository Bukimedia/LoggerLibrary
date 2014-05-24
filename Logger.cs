using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Bukimedia.LoggerLibrary
{
    enum LogLevel { Debug, Info, Warn, Error, Fatal };

    public class Logger
    {
        string LogFileName { get; set; }
        ILog Log { get; set; }

        public Logger(string LogFileName)
        {
            this.LogFileName = LogFileName;
            log4net.GlobalContext.Properties["LogFileName"] = this.LogFileName;
            log4net.Config.XmlConfigurator.Configure();
            this.Log = LogManager.GetLogger(typeof(Logger));
        }

        public void SetAllLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.All;
        }

        public void SetDebugLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Debug;
        }

        public void SetInfoLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Info;
        }

        public void SetWarnLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Warn;
        }

        public void SetErrorLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Error;
        }

        public void SetFatalLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Fatal;
        }

        public void SetOffLogLevel()
        {
            this.Log.Logger.Repository.Threshold = log4net.Core.Level.Off;
        }

        public void LogDebugStampNoNewline(string Message)
        {
            this.LogMessage(LogLevel.Debug, true, true, false, Message);
        }

        public void LogDebugNoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Debug, false, false, true, Message);
        }

        public void LogDebugStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Debug, true, true, true, Message);
        }

        public void LogInfoStampNoNewLine(string Message)
        {
            this.LogMessage(LogLevel.Info, true, true, false, Message);
        }

        public void LogInfoNoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Info, false, false, true, Message);
        }

        public void LogInfoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Info, true, true, true, Message);
        }

        public void LogWarnStampNoNewLine(string Message)
        {
            this.LogMessage(LogLevel.Warn, true, true, false, Message);
        }

        public void LogWarnNoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Warn, false, false, true, Message);
        }

        public void LogWarnStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Warn, true, true, true, Message);
        }

        public void LogErrorStampNoNewLine(string Message)
        {
            this.LogMessage(LogLevel.Error, true, true, false, Message);
        }

        public void LogErrorNoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Error, false, false, true, Message);
        }

        public void LogErrorStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Error, true, true, true, Message);
        }

        public void LogFatalStampNoNewLine(string Message)
        {
            this.LogMessage(LogLevel.Fatal, true, true, false, Message);
        }

        public void LogFatalNoStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Fatal, false, false, true, Message);
        }

        public void LogFatalStampNewLine(string Message)
        {
            this.LogMessage(LogLevel.Fatal, true, true, true, Message);
        }

        private void LogMessage(LogLevel Level, bool ShowStamp, bool ShowLevel, bool ShowNewLine, object Message)
        {
            string Stamp = "";
            string Mode = "";
            string NewLine = "";
            if (ShowStamp)
            {
                Stamp = "[" + DateTime.Now.ToString() + "] - ";
            }
            if (ShowLevel)
            {
                switch (Level)
                {
                    case LogLevel.Debug:
                        Mode = "[DEBUG] - ";
                        break;

                    case LogLevel.Info:
                        Mode = "[INFO] - ";
                        break;

                    case LogLevel.Warn:
                        Mode = "[WARN] - ";
                        break;

                    case LogLevel.Error:
                        Mode = "[ERROR] - ";
                        break;
                    case LogLevel.Fatal:
                        Mode = "[FATAL] - ";
                        break;
                }
            }
            if (ShowNewLine)
            {
                NewLine = Environment.NewLine;
            }
            switch (Level)
            {
                case LogLevel.Debug:
                    this.Log.Debug(Stamp + Mode + Message + NewLine);
                    break;

                case LogLevel.Info:
                    this.Log.Info(Stamp + Mode + Message + NewLine);
                    break;

                case LogLevel.Warn:
                    this.Log.Warn(Stamp + Mode + Message + NewLine);
                    break;

                case LogLevel.Error:
                    this.Log.Error(Stamp + Mode + Message + NewLine);
                    break;

                case LogLevel.Fatal:
                    this.Log.Fatal(Stamp + Mode + Message + NewLine);
                    break;
            }
        }

    }
}
