using log4net;
using Prototype.Services;
using Prototype.Utilities.Annotations;
using Prototype.ViewModels;
using System.Linq;
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
            System.Diagnostics.Debug.WriteLine("UserId:" + this.HttpContext.Session["UserId"]);
            var model = new ValidationTestViewModel()
            {
                MinLengthItem = "A",
                MaxLengthItem = "AAAAA",
                MinByteItem = "あ",
                MaxByteItem = "い",
                AlphabetItem = "1",
                AlphaNumberItem = "@",
                AlphaNumberSymbolItem = "あ"
            };
            //this.ViewBag.CategoryId = Enumerable.Range(1, 5).Select(p => new SelectListItem
            //{
            //    Text = "項目" + p,
            //    Value = p.ToString()
            //});
            return View(model);
        }

        /// <summary>
        /// 入力検証：保存
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpPost]
        [ButtonName("Save")]
        [ActionName("Execute")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ValidationTestViewModel model)
        {
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

        /// <summary>
        /// 入力検証：保存
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpPost]
        [ButtonName("Cancel")]
        [ActionName("Execute")]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(ValidationTestViewModel model)
        {
            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }
    }
}