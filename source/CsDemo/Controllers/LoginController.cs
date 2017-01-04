using CsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// 初期表示。
        /// </summary>
        /// <returns>アクションメソッドの結果</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ログイン処理。
        /// </summary>
        /// <param name="model">ログイン画面のViewModel</param>
        /// <returns>アクションメソッドの結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // ログインユーザのチェック

            // ユーザ情報画面に遷移
            return RedirectToAction("Index", "Home");
        }
    }
}