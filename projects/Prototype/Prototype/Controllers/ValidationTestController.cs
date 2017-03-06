using log4net;
using OfficeOpenXml;
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
    public class ValidationTestController : Controller
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
            if (this.Request.IsAjaxRequest())
            {
                if (!this.ModelState.IsValid)
                {
                    //this.Response.Clear();
                    //this.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    //this.Response.TrySkipIisCustomErrors = true;
                    return new JsonResult()
                    {
                        Data = new { Result = false }
                    };
                }
            }
            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }
    }
}