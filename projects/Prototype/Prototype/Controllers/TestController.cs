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
        public TestController(TestService testService, System.Data.Common.DbConnection connection)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            logger.Debug("TestController:Id=" + this.testService.TestComponent.Id);
            return View();
        }
    }
}