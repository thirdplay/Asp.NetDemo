using log4net;
using OfficeOpenXml;
using Prototype.Attributes;
using Prototype.Services;
using Prototype.ViewModels;
using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// 入力検証テストコントローラ。
    /// </summary>
    public class ValidationTestController : ControllerBase
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="testService">テストサービス</param>
        public ValidationTestController(TestService testService, System.Data.Common.DbConnection connection)
        {
        }

        /// <summary>
        /// 入力検証：初期表示
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 入力検証：保存
        /// </summary>
        /// <returns>JSON結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save(ValidationTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.GetJsonResultOfAjaxError();
            }

            // TODO:保存処理

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }
    }
}