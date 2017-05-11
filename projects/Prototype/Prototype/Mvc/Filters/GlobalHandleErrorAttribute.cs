using Prototype.Resources;
using NLog;
using System;
using System.Net;
using System.Web.Mvc;

namespace Prototype.Mvc.Filters
{
	/// <summary>
	/// 全てのアクションメソッドがスローした例外の処理に使用される属性を表します。
	/// </summary>
	public class GlobalHandleErrorAttribute : HandleErrorAttribute
	{
		/// <summary>
		/// ロガー
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// 例外が発生したときに呼び出されます。
		/// </summary>
		/// <param name="filterContext">アクションフィルターコンテキスト</param>
		public override void OnException(ExceptionContext filterContext)
		{
			if (filterContext == null)
			{
				throw new ArgumentNullException(nameof(filterContext));
			}

			// 例外発生時は常にログを取っておく
			logger.Error(filterContext.Exception.ToString());

			if (filterContext.HttpContext.Request.IsAjaxRequest())
			{
				// Application_Errorは呼ばれない
				HandleAjaxRequestException(filterContext);
			}
			else
			{
				// custom errorが有効でなければ
				// base.OnException()でExceptionHandledがtrueにならないので
				// Application_Errorも呼ばれる
				base.OnException(filterContext);
			}
		}

		/// <summary>
		/// Ajax要求をエラーハンドリングします。
		/// </summary>
		/// <param name="filterContext">アクションフィルターコンテキスト</param>
		private void HandleAjaxRequestException(ExceptionContext filterContext)
		{
			if (filterContext.ExceptionHandled)
			{
				return;
			}

			filterContext.Result = new JsonResult
			{
				Data = new
				{
					Result = false,
					Message = filterContext.Exception.Message ?? Messages.MS015
				},
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};

			filterContext.ExceptionHandled = true;
			filterContext.HttpContext.Response.Clear();
			filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
			filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
		}
	}
}