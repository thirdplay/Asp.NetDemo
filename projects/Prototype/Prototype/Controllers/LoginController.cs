using log4net;
using Prototype.Services;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// ログイン画面のコントローラー。
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// 初期表示アクション。
        /// </summary>
        /// <returns>アクション結果</returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}