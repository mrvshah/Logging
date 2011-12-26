using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Core;

namespace Interface.Writer
{
	[ServiceContract]
	[ServiceKnownType(typeof(LogMsmqMessage))]
	public interface IReceiverService
	{
		[OperationContract(IsOneWay = true, Action = "*")]
		void Receive(MsmqMessage<LogMsmqMessage> message);
	}
}
