using System;
using System.Reflection;
using System.Threading;
using Core;
using Interface.Sender;

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
					var ex = new ArgumentException("Ex", new Exception("Inner"));
					ex.Data.Add("Key3", "Value3");

					throw ex;
				}
				catch (Exception ex)
				{
					ex.Data.Add("Key1", "Value1");
					ex.Data.Add("Key2", "Value2");
					new Logger().Log(MethodBase.GetCurrentMethod(), LogLevel.Error, "Error", ex);
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
