using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Threading;
using Interface;
using Utilities.Log4Net;
using Utilities.Serialization;
using log4net;

namespace LogWriter
{
	public class ReceiverService : IReceiverService
	{
		[OperationBehavior]
		public void Receive(MsmqMessage<LogMsmqMessage> message)
		{
			try
			{
				var logMsmqMessage = message.Body;
				var logMessage = BinarySerializer.Deserialize<LogMessage>(logMsmqMessage.SerializedLogMessage);

				ILog log = LogWrapper.Instance.Get(logMessage.Type);

				Thread.CurrentThread.Name = logMessage.ThreadName;
				ThreadContext.Properties["DateTime"] = logMessage.Created.ToString("yyyy-MM-dd HH:mm:ss,fff");
				ThreadContext.Properties["Method"] = logMessage.Method;
				ThreadContext.Properties["Application"] = logMessage.Application;

				switch (logMessage.Action)
				{
					case LogAction.Debug:
						log.Debug(logMessage.Message, logMessage.Exception);
						break;
					case LogAction.Info:
						log.Info(logMessage.Message, logMessage.Exception);
						break;
					case LogAction.Warn:
						log.Warn(logMessage.Message, logMessage.Exception);
						break;
					case LogAction.Error:
						log.Error(logMessage.Message, logMessage.Exception);
						break;
					case LogAction.Fatal:
						log.Fatal(logMessage.Message, logMessage.Exception);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			catch (Exception ex)
			{
				LogWrapper.Instance.Get<ReceiverService>().Error("Exception logging data", ex);
			}
		}
	}
}
