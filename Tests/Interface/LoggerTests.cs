using System;
using System.Reflection;
using System.Threading;
using Interface;
using NUnit.Framework;
using Utilities.Stopwatch;

namespace Tests.Interface
{
	[TestFixture]
	public class LoggerTests
	{
		private Logger sut;

		[SetUp]
		public void SetUp()
		{
			sut = new Logger();
		}

		[Test]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendDebugMessage()
		{
			using (new ExecutionTimeTracer())
			{
				sut.LogSynchronous<LoggerTests>(MethodBase.GetCurrentMethod().Name, LogAction.Debug, "Debug Message");
			}
		}

		[Test]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendDebugMessageAsynchronously()
		{
			using (new ExecutionTimeTracer())
			{
				sut.Log<LoggerTests>(MethodBase.GetCurrentMethod().Name, LogAction.Debug, "Debug Message");
			}
			Thread.Sleep(2000);
		}

		[TestCase(LogAction.Debug, "Debug")]
		[TestCase(LogAction.Info, "Info")]
		[TestCase(LogAction.Warn, "Warn")]
		[TestCase(LogAction.Error, "Error")]
		[TestCase(LogAction.Fatal, "Fatal")]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendAMessage(LogAction logAction, object message)
		{
			sut.LogSynchronous<LoggerTests>(MethodBase.GetCurrentMethod().Name, logAction, string.Format("{0} message", message));
		}

		[TestCase(LogAction.Debug, "Debug")]
		[TestCase(LogAction.Info, "Info")]
		[TestCase(LogAction.Warn, "Warn")]
		[TestCase(LogAction.Error, "Error")]
		[TestCase(LogAction.Fatal, "Fatal")]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendAMessageWithException(LogAction logAction, object message)
		{
			var ex = new Exception("Exception");
			sut.LogSynchronous<LoggerTests>(MethodBase.GetCurrentMethod().Name, logAction, string.Format("{0} message", message), ex);
		}
	}
}