using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using Core;
using Interface.Sender;

namespace MvcWebClient.Controllers
{
	public class HomeController : Controller
	{
		private ILogger logger;

		public HomeController()
			: this(new Logger())
		{

		}

		public HomeController(ILogger logger)
		{
			Thread.CurrentThread.Name = "Home";

			this.logger = logger;
		}

		public ActionResult Index()
		{
			logger.Log(MethodBase.GetCurrentMethod(), LogLevel.Info, string.Format("Loading home page"));

			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
