using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Interface.MessageSender;
using Utilities.Configuration;

namespace Interface
{
	public class Logger : ILogger
	{
		public ILogMessageSender LogMessageSender { get; set; }

		public Logger()
			: this(new LogMsmqMessageSender())
		{

		}

		public Logger(ILogMessageSender logMessageSender)
		{
			LogMessageSender = logMessageSender;
		}

		private static readonly Lazy<ILogger> instance = new Lazy<ILogger>(true);
		[Obsolete("Use Dependency Injection to get handle of ILogger")]
		public static ILogger Instance
		{
			get { return instance.Value; }
		}

		internal void LogSynchronous<T>(string methodName, LogAction logAction, object message, Exception exception = null)
		{
			LogMessage<T>(methodName, logAction, message, exception);
		}

		public void Log<T>(string methodName, LogAction logAction, object message, Exception exception = null)
		{
			Task.Factory.StartNew(() => LogMessage<T>(methodName, logAction, message, exception));
		}

		private void LogMessage<T>(string methodName, LogAction logAction, object message, Exception exception = null)
		{
			LogMessage logMessage = GetLogMessage<T>(methodName, logAction);
			logMessage.Message = message;
			logMessage.Exception = exception;

			Send(logMessage);
		}

		private LogMessage GetLogMessage<T>(string methodName, LogAction logAction)
		{
			return new LogMessage
						{
							Action = logAction,
							Type = typeof(T).Name,
							Method = methodName,
							Application = AppSettingsReader.Get<string>("ApplicationName")
						};
		}

		private void Send(LogMessage logMessage)
		{
			Trace.WriteLine(string.Format("Sending message: {0}", logMessage));
			LogMessageSender.Send(logMessage);
		}
	}
}