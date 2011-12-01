﻿using System.Runtime.Serialization;

namespace Interface
{
	[DataContract]
	public class LogMsmqMessage
	{
		public string SerializedLogMessage { get; set; }

		public LogMsmqMessage()
			: this(string.Empty)
		{

		}

		public LogMsmqMessage(string serializedLogMessage)
		{
			SerializedLogMessage = serializedLogMessage;
		}
	}
}