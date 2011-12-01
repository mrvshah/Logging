using System;

namespace Interface
{
	public interface ILogger
	{
		void Log<T>(string methodName, LogAction logAction, object message, Exception exception = null);
	}
}