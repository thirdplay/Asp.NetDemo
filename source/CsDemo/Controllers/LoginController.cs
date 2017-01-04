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
            //UserService.Exists(model.UserId, model.Password)
            using (var db = new CsDemoContext())
            {
                var query = from x in db.USER_INFO
                            where x.USER_ID == model.UserId && x.PASSWORD == model.Password
                            select x;
                if (query.Count() != 1)
                {
                    ModelState.AddModelError("", "ユーザIDまたはパスワードが不正です。");
                    return View(model);
                }
            }

            // ユーザ情報画面に遷移
            return RedirectToAction("Index", "Home");
        }
    }
}