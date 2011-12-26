using System;
using System.Text;
using System.Threading;

namespace Core
{
	[Serializable]
	public class LogMessage
	{
		public string Machine { get; set; }
		public string ThreadName { get; set; }
		public DateTime Created { get; set; }

		public string Application { get; set; }
		public LogLevel Level { get; set; }

		public string Type { get; set; }
		public string Method { get; set; }

		public object Message { get; set; }
		public Exception Exception { get; set; }

		public LogMessage()
		{
			Created = DateTime.UtcNow;
			ThreadName = Thread.CurrentThread.Name;
			Machine = Environment.MachineName;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			stringBuilder.Append(string.Format("[Machine:{0}]", Machine));
			stringBuilder.Append(string.Format("[Application:{0}]", Application));
			stringBuilder.Append(string.Format("[ThreadName:{0}]", ThreadName));
			stringBuilder.Append(string.Format("[Created:{0}]", Created));
			stringBuilder.Append(string.Format("[Level:{0}]", Level));
			stringBuilder.Append(string.Format("[Type:{0}]", Type));
			stringBuilder.Append(string.Format("[Method:{0}]", Method));
			stringBuilder.Append(string.Format("[Message:{0}]", Message));
			stringBuilder.Append(string.Format("[Exception:{0}]", Exception));

			return stringBuilder.ToString();
		}
	}
}
