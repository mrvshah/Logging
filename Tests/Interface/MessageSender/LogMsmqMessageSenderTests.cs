using System;
using System.Messaging;
using Interface;
using Interface.MessageSender;
using NUnit.Framework;

namespace Tests.Interface.MessageSender
{
	[TestFixture]
	public class LogMsmqMessageSenderTests
	{
		private LogMsmqMessageSender sut;

		[SetUp]
		public void SetUp()
		{
			sut = new LogMsmqMessageSender();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void WhenLogMessageIsNullArgumentNullExceptionIsThrown()
		{
			sut.Send(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void WhenQueueNameIsNullArgumentNullExceptionIsThrown()
		{
			sut.Send(new LogMessage(), null);
		}

		[Test]
		[ExpectedException(typeof(MessageQueueException))]
		public void WhenQueueIsNotFoundArgumentExceptionIsThrown()
		{
			sut.Send(new LogMessage(), ".\\private$\\QueueThatDoesNotExist");
		}
	}
}