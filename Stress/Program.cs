using System;
using System.Reflection;
using Interface;

namespace Stress
{
	class Program
	{
		static void Main()
		{
			var logger = new Logger();

			for (int i = 0; i < 500000; i++)
			{
				logger.Log<Program>(MethodBase.GetCurrentMethod().Name, LogAction.Info, string.Format("Message"));
			}

			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
