using CsDemo.Models;
using CsDemo.Services;
using System;
using System.Web;
using System.Web.Mvc;

namespace CsDemo.Controllers
{
    /// <summary>
    /// ログイン画面を制御するクラスです。
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// ユーザの業務ロジック。
        /// </summary>
        private readonly UserService _service;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="service">ユーザの業務ロジック</param>
        public LoginController(UserService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Login()
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
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // ログインユーザのチェック
                User condition = new User();
                condition.UserId = model.UserId;
                condition.Password = model.Password;
                this._service.Exists(condition);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }

            // ユーザ情報画面に遷移
            return RedirectToAction("Index", "Home");
        }
    }
}