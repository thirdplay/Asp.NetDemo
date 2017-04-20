using log4net;
using Prototype.Services;
using Prototype.ViewModels;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// 入力検証テストコントローラー。
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
            var model = new ValidationTestViewModel()
            {
                MinLengthItem = "A",
                MaxLengthItem = "AAAAA",
                MinByteItem = "あ",
                MaxByteItem = "い",
                AlphabetItem = "あ"
            };
            return View(model);
        }

        /// <summary>
        /// 入力検証：保存
        /// </summary>
        /// <returns>JSON結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save(ValidationTestViewModel model)
        {
            //ボタンのPOST有無で振り分け
            //this.Request.Form["Save"]
            if (!this.ModelState.IsValid)
            {
                return GetErrorResult();
            }

            // TODO:保存処理

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }
    }
}