using AspDotNetDemo.Models;
using AspDotNetDemo.Services;
using System;
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
        /// 初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Index()
        {
            return View(this._service.ListAll());
        }
    }
}