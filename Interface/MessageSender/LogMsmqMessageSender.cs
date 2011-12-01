using System;
using System.Diagnostics;
using System.Messaging;
using Utilities.Arguments;
using Utilities.Serialization;

namespace Interface.MessageSender
{
	internal class LogMsmqMessageSender : ILogMessageSender
	{
		public void Send(LogMessage logMessage, string queueName = @".\private$\LogMessages")
		{
			logMessage.ThrowIfNull("logMessage");
			queueName.ThrowIfNull("queueName");

			try
			{
				using (var queue = new MessageQueue(string.Format(@"FormatName:Direct=OS:{0}", queueName)))
				{
					var message = new Message { Label = "LogMsmqMessage", Body = new LogMsmqMessage(BinarySerializer.Serialize(logMessage)) };

					queue.Send(message);
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex);
				throw;
			}
		}
	}
}