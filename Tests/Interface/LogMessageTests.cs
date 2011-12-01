using System;
using System.Threading;
using Interface;
using NUnit.Framework;

namespace Tests.Interface
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
			const string threadName = "Worker";
			Thread.CurrentThread.Name = threadName;

			Assert.That(new LogMessage().ThreadName, Is.EqualTo(threadName));
		}

		[Test]
		public void DateTimePropertyIsSetOnInitializationOfLogMessage()
		{
			Assert.That(new LogMessage().Created.Date, Is.EqualTo(DateTime.UtcNow.Date));
		}
	}
}