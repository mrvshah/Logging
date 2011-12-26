using Core;

namespace Interface.Sender.MessageSender
{
	public interface ILogMessageSender
	{
		void Send(LogMessage logMessage, string queueName = @".\private$\LogMessages");
	}
}