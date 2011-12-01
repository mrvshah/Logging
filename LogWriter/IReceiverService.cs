using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Interface;

namespace LogWriter
{
	[ServiceContract]
	[ServiceKnownType(typeof(LogMsmqMessage))]
	public interface IReceiverService
	{
		[OperationContract(IsOneWay = true, Action = "*")]
		void Receive(MsmqMessage<LogMsmqMessage> message);
	}
}
