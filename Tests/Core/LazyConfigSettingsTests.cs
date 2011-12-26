using System.Configuration;
using Core;
using NUnit.Framework;
using Utilities.Stopwatch;

namespace Tests.Core
{
	[TestFixture]
	public class LazyConfigSettingsTests
	{
		[Test]
		public void ConfigPropertiesAreSetOnInitialization()
		{
			var configSettings = new LazyConfigSettings();

			Assert.That(configSettings.ApplicationName, Is.EqualTo(ConfigurationManager.AppSettings["ApplicationName"]));
			Assert.That(configSettings.LogLevel, Is.EqualTo((LogLevel)int.Parse(ConfigurationManager.AppSettings["LoggingLevel"])));
			Assert.That(configSettings.LoggingQueue, Is.EqualTo(ConfigurationManager.AppSettings["LoggingQueue"]));
		}

		[Test]
		public void CostOfRetrievingConfigValuesOnInitialization()
		{
			using (new ExecutionTimeTracer())
			{
				new LazyConfigSettings();
			}
			// 2 ms
		}
	}
}