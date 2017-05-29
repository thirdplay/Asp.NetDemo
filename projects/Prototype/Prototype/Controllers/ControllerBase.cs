using Prototype.Mvc.Extensions;
using Prototype.Resources;
using System.Web.Mvc;

namespace Prototype.Controllers
{
	/// <summary>
	/// コントローラーの基底クラス。
	/// </summary>
	[Authorize]
	public abstract class ControllerBase : Controller
	{
		/// <summary>
		/// アクション メソッドの呼び出し前に呼び出されます。
		/// </summary>
		/// <param name="filterContext">現在の要求およびアクションに関する情報</param>
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (HttpContext.Request.IsAjaxRequest() && !ModelState.IsValid)
			{
				filterContext.Result = GetErrorResult();
			}
		}

		/// <summary>
		/// エラー時のJSON結果を取得します。
		/// </summary>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>JSON結果</returns>
		protected JsonResult GetErrorResult(string message = null)
		{
			message = message ?? Messages.MS013;
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