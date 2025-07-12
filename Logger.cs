using LiveSplit.Updates;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.ItTakesTwo
{
    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARN,
        ERROR
    }

    public class Logger(string logName)
    {
        private static Component ITT;
        private const string LOGDIR = "Logs";
        private const string LOGFILE = LOGDIR + "/ItTakesTwo.log";
        private static bool hasLog = false;
        private static bool isInitialized = false;

        private static readonly ConcurrentDictionary<string, Logger> loggers = new();
        private static LogLevel globalLogLevel = LogLevel.INFO;
        private readonly string name = logName;

        public static Logger GetLogger(string logName)
        {
            if ( ITT == null)
            {
                throw new InvalidOperationException("ItTakesTwoComponent must be set before creating a logger.");
            }

            return loggers.GetOrAdd(logName, _name => new Logger(_name));
        }

        

        public static void InitLog(Component comp, LogLevel logLevel = LogLevel.INFO)
        {
            if (isInitialized) return;
            if (comp == null) return;

            ITT = comp;
#if DEBUG
            logLevel = LogLevel.DEBUG;
#endif
            globalLogLevel = logLevel;
            hasLog = File.Exists(LOGFILE);

            

            if (!hasLog)
            {
                Directory.CreateDirectory(LOGDIR);
                File.Create(LOGFILE);
                hasLog = true;
            }

            if (!hasLog)
            {
                return;
            }

            // Just making sure it doesn't get SUPER long
            DateTime creationTime = File.GetCreationTime(LOGFILE);
            if ((DateTime.Now - creationTime).TotalDays > 30)
            {
                File.Delete(LOGFILE);
                File.Create(LOGFILE);
            }

            isInitialized = true;
        }

        public void Log(LogLevel level, string message)
        {
            if (level < globalLogLevel) return;

            switch (level)
            {
                case LogLevel.DEBUG:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
                case LogLevel.INFO:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
                case LogLevel.WARN:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
                case LogLevel.ERROR:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
                default:
                break;
            }

            TimeSpan ingameTime = (ITT.CurrentRun.Model != null && ITT.CurrentRun.Model.CurrentState.CurrentTime.GameTime.HasValue) 
                ? ITT.CurrentRun.Model.CurrentState.CurrentTime.GameTime.Value 
                : TimeSpan.Zero;


            string logMessage = string.Format(
                "[{0:yyyy-MM-dd HH:mm:ss.fff} | {1:hh\\:mm\\:ss\\.fff}] {2} {4}",
                DateTime.Now,
                ingameTime,
                level.ToString().PadRight(5),
                name.PadRight(5),
                message);

            Console.WriteLine(logMessage);

            if (hasLog)
            {
                using StreamWriter wr = new StreamWriter(LOGFILE, true);
                wr.WriteLine(logMessage);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogWithFormat(LogLevel level, string format, params object[] arg)
        {
            if (arg == null)
                Log(level, format);

            else
                Log(level, String.Format(format, arg));
        }

        public void Debug(string message)                       => Log(LogLevel.DEBUG, message);
        public void Debug(string format, params object[] arg)   => LogWithFormat(LogLevel.DEBUG, format, arg);
        public void Info(string message)                        => Log(LogLevel.INFO, message);
        public void Info(string format, params object[] arg)    => LogWithFormat(LogLevel.INFO, format, arg);
        public void Warning(string message)                     => Log(LogLevel.WARN, message);
        public void Warning(string format, params object[] arg) => LogWithFormat(LogLevel.WARN, format, arg);
        public void Error(string message)                       => Log(LogLevel.ERROR, message);
        public void Error(string format, params object[] arg)   => LogWithFormat(LogLevel.ERROR, format, arg);

        public void Header(LogLevel level, string message) => Log(level, "----------" + message.PadRight(40, '-'));

    }
}
