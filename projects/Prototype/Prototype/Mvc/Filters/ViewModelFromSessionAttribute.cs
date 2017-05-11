using Prototype.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prototype.Mvc.Filters
{
	/// <summary>
	/// アクション実行前にセッションからViewModelを取得する属性を表します。
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class ViewModelFromSessionAttribute : ActionFilterAttribute
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
		public ViewModelFromSessionAttribute(string paramName = "model")
		{
			this.ParamName = paramName;
		}

		/// <summary>
		/// セッションからViewModelを取得します。
		/// </summary>
		/// <param name="filterContext">フィルター コンテキスト</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			// セッションキーの取得
			if (string.IsNullOrEmpty(SessionKey))
			{
				var controllerName = filterContext.RouteData.Values["controller"].ToString();
				SessionKey = Constants.SessionKey.CreateExtractedCondition(controllerName);
			}

			// アクションパラメータのチェック
			if (!filterContext.ActionParameters.ContainsKey(ParamName))
			{
				throw new ArgumentException(nameof(ParamName));
			}

			// ViewModelの取得
			var model = filterContext.HttpContext.Session[SessionKey] as ViewModelBase;
			if (model == null)
			{
				return;
			}

			// ViewModelの設定
			filterContext.ActionParameters[ParamName] = model;
			model.IsLoaded = true;
		}
	}
}