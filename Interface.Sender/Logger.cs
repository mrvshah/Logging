using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Core;
using Interface.Sender.MessageSender;

namespace Interface.Sender
{
	public class Logger : ILogger
	{
		public ILogMessageSender LogMessageSender { get; set; }
		public ILazyConfigSettings ConfigSettings { get; set; }

		public Logger()
			: this(new LogMsmqMessageSender(), new LazyConfigSettings())
		{

		}

		public Logger(ILogMessageSender logMessageSender, ILazyConfigSettings configSettings)
		{
			LogMessageSender = logMessageSender;
			ConfigSettings = configSettings;
		}

		public void Log(MethodBase methodBase, LogLevel logLevel, object message, Exception exception = null, bool asynchronously = true)
		{
			if (logLevel > ConfigSettings.LogLevel)
			{
				return;
			}

			CreateLogMessageAndSend(methodBase, logLevel, message, exception, asynchronously);
		}

		private void CreateLogMessageAndSend(MethodBase methodBase, LogLevel logLevel, object message, Exception exception, bool asynchronously)
		{
			var logMessage = new LogMessage();

			if (asynchronously)
			{
				Task.Factory.StartNew(() =>
												{
													FillLogMessage(logMessage, methodBase, logLevel, message, exception);
													Send(logMessage);
												});
			}
			else
			{
				FillLogMessage(logMessage, methodBase, logLevel, message, exception);
				Send(logMessage);
			}
		}

		private void FillLogMessage(LogMessage logMessage, MethodBase methodBase, LogLevel logLevel, object message, Exception exception = null)
		{
			logMessage.Level = logLevel;
			logMessage.Type = methodBase.DeclaringType.Name;
			logMessage.Method = methodBase.Name;
			logMessage.Application = ConfigSettings.ApplicationName;
			logMessage.Message = message;
			logMessage.Exception = exception;
		}

		private void Send(LogMessage logMessage)
		{
			Trace.WriteLine(string.Format("Sending message: {0}", logMessage));
			LogMessageSender.Send(logMessage, ConfigSettings.LoggingQueue);
		}
	}
}