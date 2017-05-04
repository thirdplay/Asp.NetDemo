using log4net;
using Prototype.Services;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// ホームコントローラー。
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 初期表示。
        /// </summary>
        /// <returns>アクション結果</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About。
        /// </summary>
        /// <returns>アクション結果</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 連絡先。
        /// </summary>
        /// <returns>アクション結果</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}