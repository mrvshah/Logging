using System;
using System.Threading;
using Core;
using NUnit.Framework;
using Utilities.Threading;

namespace Tests.Core
{
	[TestFixture]
	public class LogMessageTests
	{
		[Test]
		public void LogMessageHasSerializableAttribute()
		{
			var attributes = typeof(LogMessage).GetCustomAttributes(typeof(SerializableAttribute), false);

			Assert.That(attributes.Length, Is.EqualTo(1));
		}

		[Test]
		public void CanInitializeLogMessageWithAnEmptyConstructor()
		{
			new LogMessage();
		}

		[Test]
		public void ThreadNamePropertyIsSetOnInitializationOfLogMessage()
		{
			// try to set it, but if it doesn't work then set threadName variable to the name already set
			// we're only check that ThreadName property is set to whatever name is set in CurrentThread
			string threadName = "Worker";
			Thread.CurrentThread.TrySetName(threadName);
			threadName = Thread.CurrentThread.Name;

			Assert.That(new LogMessage().ThreadName, Is.EqualTo(threadName));
		}

		[Test]
		public void DateTimePropertyIsSetOnInitializationOfLogMessage()
		{
			Assert.That(new LogMessage().Created.Date, Is.EqualTo(DateTime.UtcNow.Date));
		}

		[Test]
		public void MachinePropertyIsSetOnInitializationOfLogMessage()
		{
			Assert.That(new LogMessage().Machine, Is.EqualTo(Environment.MachineName));
		}
	}
}