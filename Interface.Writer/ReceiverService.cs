using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Core;
using Utilities.Log4Net;
using Utilities.Serialization;
using log4net;

namespace Interface.Writer
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
	public class ReceiverService : IReceiverService
	{
		public void Receive(MsmqMessage<LogMsmqMessage> message)
		{
			try
			{
				var logMsmqMessage = message.Body;
				var logMessage = BinarySerializationHelper.Deserialize<LogMessage>(logMsmqMessage.SerializedLogMessage);

				ILog log = LogWrapper.Instance.Get(logMessage.Type);

				ThreadContext.Properties["DateTime"] = logMessage.Created.ToString("yyyy-MM-dd HH:mm:ss,fff");
				ThreadContext.Properties["Method"] = logMessage.Method;
				ThreadContext.Properties["Machine"] = logMessage.Machine;
				ThreadContext.Properties["ThreadName"] = logMessage.ThreadName;
				ThreadContext.Properties["Application"] = logMessage.Application;
				ThreadContext.Properties["Type"] = logMessage.Type;

				switch (logMessage.Level)
				{
					case LogLevel.Debug:
						log.Debug(logMessage.Message, logMessage.Exception);
						break;
					case LogLevel.Info:
						log.Info(logMessage.Message, logMessage.Exception);
						break;
					case LogLevel.Warn:
						log.Warn(logMessage.Message, logMessage.Exception);
						break;
					case LogLevel.Error:
						log.Error(logMessage.Message, logMessage.Exception);
						break;
					case LogLevel.Fatal:
						log.Fatal(logMessage.Message, logMessage.Exception);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(string.Format("Exception logging data. {0}", ex));
			}
		}
	}
}
