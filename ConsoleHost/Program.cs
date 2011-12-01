using System;
using System.ServiceModel;
using LogWriter;

namespace ConsoleHost
{
	class Program
	{
		static void Main()
		{
			using (var serviceHost = new ServiceHost(typeof(ReceiverService)))
			{
				serviceHost.Open();

				Console.WriteLine("Service started");
				Console.WriteLine("Press any key to continue");
				Console.ReadKey();
			}
		}
	}
}
