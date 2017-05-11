using Prototype.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prototype.Mvc.Filters
{
	/// <summary>
	/// アクション実行前にViewModelをセッションに設定する属性を表します。
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class ViewModelToSessionAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// セッションに設定するViewModelの引数名
		/// </summary>
		public string ParamName { get; set; }

		/// <summary>
		/// 設定するセッションのキー
		/// </summary>
		public string SessionKey { get; set; }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="paramName">セッションに設定するViewModelの引数名</param>
		public ViewModelToSessionAttribute(string paramName = "model")
		{
			this.ParamName = paramName;
		}

		/// <summary>
		/// ViewModelをセッションに設定します。
		/// </summary>
		/// <param name="filterContext">フィルター コンテキスト</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			// ViewModelの取得
			object model;
			if (!filterContext.ActionParameters.TryGetValue(ParamName, out model))
			{
				throw new ArgumentException(nameof(ParamName));
			}

			// セッションキーの取得
			if (string.IsNullOrEmpty(SessionKey))
			{
				var controllerName = filterContext.RouteData.Values["controller"].ToString();
				SessionKey = Constants.SessionKey.CreateExtractedCondition(controllerName);
			}

			// セッションの設定
			filterContext.HttpContext.Session[SessionKey] = model;
		}
	}
}