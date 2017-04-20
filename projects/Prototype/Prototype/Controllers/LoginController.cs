using Prototype.ViewModels;
using System;
using System.Reflection;
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
        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("UserId:" + this.HttpContext.Session["UserId"]);
            return View();
        }

        /// <summary>
        /// ログイン。
        /// </summary>
        /// <param name="model">ログインViewModel</param>
        /// <returns>アクション結果</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return GetErrorResult();
            }

            // ログイン処理
            FormsAuthentication.SetAuthCookie(model.UserId, false);
            this.HttpContext.Session["UserId"] = model.UserId;

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }

        /// <summary>
        /// ログアウト。
        /// </summary>
        /// <returns>アクション結果</returns>
        public ActionResult Logout()
        {
            // ログアウト処理
            FormsAuthentication.SignOut();
            this.HttpContext.Session.RemoveAll();

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }
    }
}