using NLog;
using Prototype.Constants;
using Prototype.ViewModels;
using System;
using System.Diagnostics;
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
		private static readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();

		/// <summary>
		/// 初期表示アクション。
		/// </summary>
		/// <returns>アクション結果</returns>
		[HttpGet]
		public ActionResult Index(LoginViewModel model)
		{
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