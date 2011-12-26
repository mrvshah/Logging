using System.Runtime.Serialization;
using Core;
using NUnit.Framework;

namespace Tests.Core
{
	[TestFixture]
	public class LogMsmqMessageTests
	{
		[Test]
		public void LogMsmqMessageClassHasDataContractAttribute()
		{
			var attributes = typeof(LogMsmqMessage).GetCustomAttributes(typeof(DataContractAttribute), false);

			Assert.That(attributes.Length, Is.EqualTo(1));
		}

		[Test]
		public void CanInitializeLogMsmqMessageWithAnEmptyConstructor()
		{
			new LogMsmqMessage();
		}

		[Test]
		public void SerializedLogMessageIsEmptyStringWhenLogMsmqMessageIsInitializedUsingEmptyConstructor()
		{
			Assert.That(new LogMsmqMessage().SerializedLogMessage, Is.EqualTo(string.Empty));
		}

		[Test]
		public void CanInitializeLogMsmqMessageByPassingSerializedLogMessageString()
		{
			const string serializedLogMessage = "ABC";

			Assert.That(new LogMsmqMessage(serializedLogMessage).SerializedLogMessage, Is.EqualTo(serializedLogMessage));
		}
	}
}