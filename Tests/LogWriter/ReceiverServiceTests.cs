using System.ServiceModel;
using LogWriter;
using NUnit.Framework;

namespace Tests.LogWriter
{
	[TestFixture]
	public class ReceiverServiceTests
	{
		private ReceiverService sut;

		[SetUp]
		public void SetUp()
		{
			sut = new ReceiverService();
		}

		[Test]
		public void ReceiverServiceHasServiceContractAttribute()
		{
			var attributes = typeof(ReceiverService).GetInterface("IReceiverService").GetCustomAttributes(typeof(ServiceContractAttribute), false);

			Assert.That(attributes.Length, Is.EqualTo(1));
		}
	}
}