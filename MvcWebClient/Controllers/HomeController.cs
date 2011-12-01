using System.Reflection;
using System.Web.Mvc;
using Interface;

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
			this.logger = logger;
		}

		public ActionResult Index()
		{
			logger.Log<HomeController>(MethodBase.GetCurrentMethod().Name, LogAction.Info, string.Format("Message"));

			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
