using System;
using System.Reflection;
using Core;

namespace Interface.Sender
{
	public interface ILogger
	{
		void Log(MethodBase methodBase, LogLevel logLevel, object message, Exception exception = null, bool asynchronously = true);
	}
}