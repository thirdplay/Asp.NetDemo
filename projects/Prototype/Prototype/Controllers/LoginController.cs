using Prototype.Constants;
using Prototype.ViewModels;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;

namespace Prototype.Controllers
{
    /// <summary>
    /// ログイン画面のコントローラー。
    /// </summary>
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 初期表示アクション。
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Index(LoginViewModel model)
        {
            //#if DEBUG
            //            var hostName = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;
            //            model.UserId = "a" + Regex.Replace(hostName, @"[^0-9]", "").Substring(3, 7);
            //#endif
            //System.Diagnostics.Debug.WriteLine("UserId:" + this.HttpContext.Session["UserId"]);
            //System.Diagnostics.Debug.WriteLine("UrlReferrer:" + this.HttpContext.Request.UrlReferrer);
            //System.Diagnostics.Debug.WriteLine("ReturnUrl:" + this.HttpContext.Request.Params.Get("ReturnUrl"));

            return View(model);
        }

        /// <summary>
        /// ログイン。
        /// </summary>
        /// <param name="model">ログインViewModel</param>
        /// <returns>アクション結果</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            // ログイン処理
            FormsAuthentication.SetAuthCookie(model.UserId, false);
            this.HttpContext.Session[SessionKey.UserId] = model.UserId;

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }

        /// <summary>
        /// ログアウト。
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            // ログアウト処理
            FormsAuthentication.SignOut();
            this.HttpContext.Session.RemoveAll();

            return RedirectToAction("Index");
        }
    }
}