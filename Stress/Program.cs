using System;
using System.Reflection;
using Core;
using Interface.Sender;

namespace Stress
{
	class Program
	{
		static void Main()
		{
			var logger = new Logger();

			for (int i = 0; i < 500000; i++)
			{
				logger.Log(MethodBase.GetCurrentMethod(), LogLevel.Info, string.Format("Message"));
			}

			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
