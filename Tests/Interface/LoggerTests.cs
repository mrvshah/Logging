using System;
using System.Reflection;
using System.Threading;
using Core;
using Interface.Sender;
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
		public void CanSendDebugMessageSynchronouslyProvidingMethodBase()
		{
			using (new ExecutionTimeTracer())
			{
				sut.Log(MethodBase.GetCurrentMethod(), LogLevel.Debug, "Debug Message", null, false); // to warm up
			}
			using (new ExecutionTimeTracer())
			{
				sut.Log(MethodBase.GetCurrentMethod(), LogLevel.Debug, "Debug Message", null, false);
			}
		}

		[Test]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendDebugMessageAsynchronouslyProvidingMethodBase()
		{
			using (new ExecutionTimeTracer())
			{
				sut.Log(MethodBase.GetCurrentMethod(), LogLevel.Debug, "Debug Message"); // to warm up
			}
			using (new ExecutionTimeTracer())
			{
				sut.Log(MethodBase.GetCurrentMethod(), LogLevel.Debug, "Debug Message");
			}
			Thread.Sleep(2000);
		}

		[TestCase(LogLevel.Debug, "Debug")]
		[TestCase(LogLevel.Info, "Info")]
		[TestCase(LogLevel.Warn, "Warn")]
		[TestCase(LogLevel.Error, "Error")]
		[TestCase(LogLevel.Fatal, "Fatal")]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendAMessage(LogLevel logAction, object message)
		{
			sut.Log(MethodBase.GetCurrentMethod(), logAction, string.Format("{0} message", message), null, false);
		}

		[TestCase(LogLevel.Debug, "Debug")]
		[TestCase(LogLevel.Info, "Info")]
		[TestCase(LogLevel.Warn, "Warn")]
		[TestCase(LogLevel.Error, "Error")]
		[TestCase(LogLevel.Fatal, "Fatal")]
		[Ignore(TestCategories.INTEGRATION)]
		public void CanSendAMessageWithException(LogLevel logAction, object message)
		{
			var ex = new Exception("Exception");
			sut.Log(MethodBase.GetCurrentMethod(), logAction, string.Format("{0} message", message), ex, false);
		}
	}
}