using Prototype.Services;
using Prototype.Mvc.Annotations;
using Prototype.ViewModels;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Prototype.Constants;
using NLog;

namespace Prototype.Controllers
{
    /// <summary>
    /// 入力検証テストコントローラー。
    /// </summary>
    public class ValidationTestController : ControllerBase
    {
        /// <summary>
        /// ロギングインターフェース
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="testService">テストサービス</param>
        public ValidationTestController(TestService testService)
        {
        }

        /// <summary>
        /// 入力検証：初期表示
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Index()
        {
            ValidationTestViewModel model;
            if (this.HttpContext.Session["ValidationTest.ViewModel"] != null)
            {
                model = this.HttpContext.Session["ValidationTest.ViewModel"] as ValidationTestViewModel;
            }
            else
            {
                model = new ValidationTestViewModel()
                {
                    MinLengthItem = "A",
                    MaxLengthItem = "AAAAA",
                    MinByteItem = "あ",
                    MaxByteItem = "い",
                    AlphabetItem = "1",
                    AlphaNumberItem = "@",
                    AlphaNumberSymbolItem = "あ",
                    NumberItem = "-1"
                };
            }
            System.Diagnostics.Debug.WriteLine("UserId:" + this.HttpContext.Session[SessionKey.UserId]);
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
            this.HttpContext.Session["ValidationTest.ViewModel"] = model;

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