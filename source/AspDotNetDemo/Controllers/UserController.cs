using AspDotNetDemo.Models;
using AspDotNetDemo.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetDemo.Controllers
{
    /// <summary>
    /// ユーザ情報画面を制御するクラスです。
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// ユーザの業務ロジック。
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="service">ユーザの業務ロジック</param>
        public UserController(UserService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 一覧の初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Index()
        {
            var users = this._service.ListAll();
            return View(Mapper.Map<List<UserIndexViewModel>>(users));
        }

        /// <summary>
        /// 新規作成の初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Create()
        {
            return View("Edit");
        }

        /// <summary>
        /// 新規作成の登録処理。
        /// </summary>
        /// <param name="user">ユーザ情報</param>
        /// <returns>アクションの結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            // TODO:登録処理
            if (this._service.Find(user.UserId) != null)
            {
                ModelState.AddModelError("", "既に登録されているユーザIDです。");
                return View("Edit", user);
            }

            this._service.Add(user);
            this._service.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 編集の初期表示。
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <param name="mode">画面モード</param>
        /// <returns>アクションの結果</returns>
        public ActionResult Edit(string id, string mode)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = this._service.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<User, UserEditViewModel>(user);

            return View(model);
        }

        /// <summary>
        /// 編集の更新処理。
        /// </summary>
        /// <param name="user">ユーザ情報</param>
        /// <returns>アクションの結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // TODO:更新処理
            var dbUser = this._service.Find(user.UserId);
            if (dbUser == null)
            {
                ModelState.AddModelError("", "存在しないユーザIDです。");
                return View();
            }

            UpdateModel(dbUser);
            this._service.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 削除の初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = this._service.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<User, UserDeleteViewModel>(user);

            return View(model);
        }

        /// <summary>
        /// 確認後の削除処理。
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <returns>アクションの結果</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // TODO:削除処理
            var dbUser = this._service.Find(id);
            if (dbUser == null)
            {
                ModelState.AddModelError("", "存在しないユーザIDです。");
                return View();
            }

            this._service.Remove(dbUser);
            this._service.Save();

            return RedirectToAction("Index");
        }
    }
}