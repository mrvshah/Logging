using System;
using Utilities.Configuration;

namespace Core
{
	public class LazyConfigSettings : ILazyConfigSettings
	{
		private readonly Lazy<int> loggingLevel;
		private int LoggingLevel
		{
			get
			{
				return loggingLevel.Value;
			}
		}

		private readonly Lazy<LogLevel> logLevel;
		public LogLevel LogLevel
		{
			get
			{
				return logLevel.Value;
			}
		}

		private readonly Lazy<string> applicationName;
		public string ApplicationName
		{
			get
			{
				return applicationName.Value;
			}
		}

		private readonly Lazy<string> loggingQueue;
		public string LoggingQueue
		{
			get
			{
				return loggingQueue.Value;
			}
		}

		public LazyConfigSettings()
		{
			loggingLevel = new Lazy<int>(() => AppSettingsReader.Get<int>("LoggingLevel"));
			logLevel = new Lazy<LogLevel>(() => (LogLevel)LoggingLevel);
			applicationName = new Lazy<string>(() => AppSettingsReader.Get<string>("ApplicationName"));
			loggingQueue = new Lazy<string>(() => AppSettingsReader.Get<string>("LoggingQueue"));
		}
	}
}