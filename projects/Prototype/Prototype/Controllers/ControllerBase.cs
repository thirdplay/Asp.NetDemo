using Prototype.Extensions;
using Resources;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// コントローラーの基底クラス。
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// エラー時のJSON結果を取得します。
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>JSON結果</returns>
        protected JsonResult GetErrorResult(string message = null)
        {
            message = message ?? Messages.MS012;
            return new JsonResult()
            {
                Data = new
                {
                    Result = false,
                    Message = message,
                    Errors = this.ModelState.GetErrors()
                }
            };
        }
    }
}