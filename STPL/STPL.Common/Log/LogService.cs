using log4net.Config;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.Log
{
    public class LogService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogService));

        static LogService()
        {
            XmlConfigurator.Configure();
        }


        public void Info(string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Info(LogMessage(callingFrame, methodName, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }


        public void Warn(string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Warn(LogMessage(callingFrame, methodName, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }

        public void Error(Exception e, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Error(LogErrorMessage(callingFrame, methodName, "", e.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }

        public void Error(string refNo, string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Error(LogErrorMessage(callingFrame, methodName, message, ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }

        private static string LogMessage(StackFrame callingFrame, string methodName, string message)
        {
            return $"{GetCallingNamespace(callingFrame)}      {methodName}        {message}";
        }

        private static string LogErrorMessage(StackFrame callingFrame, string methodName, string message, string exception)
        {
            return $"{GetCallingNamespace(callingFrame)}      {methodName}        {message}        {exception}";
        }

        private static string GetClassName(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                return Path.GetFileNameWithoutExtension(filePath);
            }

            return "UnknownClass";
        }
        public static string GetCallingNamespace(StackFrame callingFrame)
        {
            if (callingFrame != null)
            {
                System.Reflection.MethodBase callingMethod = callingFrame.GetMethod();

                if (callingMethod != null)
                {
                    Type declaringType = callingMethod.DeclaringType;

                    if (declaringType != null)
                    {
                        return declaringType.Namespace;
                    }
                }
            }

            return string.Empty;
        }
    }
}
