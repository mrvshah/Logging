using System;
using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;

namespace Interface.Writer
{
	public class ExceptionDataPatternConverter : PatternLayoutConverter
	{
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			if (loggingEvent.ExceptionObject == null)
			{
				return;
			}
			var data = loggingEvent.ExceptionObject.Data;
			foreach (var key in data.Keys)
			{
				writer.Write("Data[{0}]={1}" + Environment.NewLine, key, data[key]);
			}
		}
	}
}