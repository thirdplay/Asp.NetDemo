using log4net;
using Prototype.Services;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// テストサービス。
        /// </summary>
        private readonly TestService testService;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="testService">テストサービス</param>
        public TestController(Microsoft.Practices.ServiceLocation.IServiceLocator serviceLocator)
        {
            this.testService = serviceLocator.GetInstance<TestService>();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}