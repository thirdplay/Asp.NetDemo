using AspDotNetDemo.Models;
using AspDotNetDemo.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspDotNetDemo.Controllers
{
    /// <summary>
    /// ログイン画面を制御するクラスです。
    /// </summary>
    [AllowAnonymous]
    public class LoginController : Controller
    {
        /// <summary>
        /// メンバーシッププロバイダー。
        /// </summary>
        private readonly CustomMembershipProvider _membershipProvider;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="service">ユーザの業務ロジック</param>
        public LoginController(CustomMembershipProvider provider)
        {
            this._membershipProvider = provider;
        }

        /// <summary>
        /// 初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ログイン処理。
        /// </summary>
        /// <param name="model">ログイン画面のViewModel</param>
        /// <returns>アクションの結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this._membershipProvider.ValidateUser(model.UserId, model.Password))
                {
                    string userId = (string)Session["AuthUserId"];
                    FormsAuthentication.SetAuthCookie(userId, false);
                    return RedirectToAction("Index", "User");
                }
            }
            ModelState.AddModelError("", "ユーザIDまたはパスワードが不正です。");
            return View(model);
        }

        /// <summary>
        /// ログアウト処理。
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["AuthUserId"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}