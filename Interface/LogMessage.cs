using System;
using System.Text;
using System.Threading;

namespace Interface
{
	[Serializable]
	public class LogMessage
	{
		public string Application { get; set; }
		public string ThreadName { get; set; }
		public DateTime Created { get; set; }

		public LogAction Action { get; set; }

		public string Type { get; set; }
		public string Method { get; set; }

		public object Message { get; set; }
		public Exception Exception { get; set; }

		public LogMessage()
		{
			Created = DateTime.UtcNow;
			ThreadName = Thread.CurrentThread.Name;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			stringBuilder.Append(string.Format("[Application:{0}]", Application));
			stringBuilder.Append(string.Format("[ThreadName:{0}]", ThreadName));
			stringBuilder.Append(string.Format("[Created:{0}]", Created));
			stringBuilder.Append(string.Format("[Action:{0}]", Action));
			stringBuilder.Append(string.Format("[Type:{0}]", Type));
			stringBuilder.Append(string.Format("[Method:{0}]", Method));

			return stringBuilder.ToString();
		}
	}
}
