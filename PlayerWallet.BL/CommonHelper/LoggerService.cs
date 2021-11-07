using NLog;
using NLog.Web;
using PlayerWallet.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerWallet.BL.CommonHelper
{
    public class LoggerService : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message, Exception ex)
        {
            logger.Error($" {message}. \n Inner Exception:-  {ex.InnerException} \n Error message :- {ex.Message} \n Date and Time {DateTime.Now}" );
        }
        public void LogInfo(string message)
        {
            logger.Info($" {message}. \n Date and Time {DateTime.Now}");
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
