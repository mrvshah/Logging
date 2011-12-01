using System;
using System.Reflection;
using System.Threading;
using Interface;

namespace ConsoleClient
{
	class Program
	{
		static void Main()
		{
			try
			{
				Thread.CurrentThread.Name = "ConsoleClientThread";

				try
				{
					throw new Exception("Ex", new Exception("Inner"));
				}
				catch (Exception ex)
				{
					ex.Data.Add("Key", "Value");
					new Logger().Log<Program>(MethodBase.GetCurrentMethod().Name, LogAction.Error, "Error", ex);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			Console.WriteLine("Message sent");
			Console.WriteLine("Press any key");
			Console.ReadKey();
		}
	}
}
