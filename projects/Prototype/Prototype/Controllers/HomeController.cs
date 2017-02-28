using log4net;
using Prototype.Services;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestService testService;
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public HomeController(TestService testService)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}