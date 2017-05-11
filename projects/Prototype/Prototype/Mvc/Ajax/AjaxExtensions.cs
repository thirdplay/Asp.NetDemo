using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Prototype.Mvc.Ajax
{
	/// <summary>
	/// AJAXの拡張機能を提供します。
	/// </summary>
	public static class AjaxExtensions
	{
		/// <summary>
		/// AJAX スクリプトを実行するためのオプション設定を作成します。
		/// </summary>
		/// <typeparam name="TModel">モデルの型</typeparam>
		/// <param name="ajaxHelper">AJAX を使用した HTML マークアップの表示に使用される <see cref="AjaxHelper"/> オブジェクト</param>
		/// <param name="httpMethod">HTTP 要求メソッド ("Get" または "Post")</param>
		/// <param name="onBegin">ページが更新される直前に呼び出される JavaScript 関数の名前</param>
		/// <param name="onComplete">応答データがインスタンス化された後、ページが更新される前に呼び出される JavaScript 関数</param>
		/// <param name="onFailure">ページの更新が失敗した場合に呼び出される JavaScript 関数</param>
		/// <param name="onSuccess">ページが正常に更新された後に呼び出される JavaScript 関数</param>
		/// <returns>AJAX スクリプトを実行するためのオプション設定</returns>
		public static AjaxOptions CreateAjaxOptions<TModel>(this AjaxHelper<TModel> ajaxHelper,
			[Optional, DefaultParameterValue("POST")] string httpMethod,
			[Optional, DefaultParameterValue("PROTOTYPE.ajax.onBegin")] string onBegin,
			[Optional, DefaultParameterValue("PROTOTYPE.ajax.onComplete")] string onComplete,
			[Optional, DefaultParameterValue("PROTOTYPE.ajax.onFailure")] string onFailure,
			[Optional, DefaultParameterValue("PROTOTYPE.ajax.onSuccess")] string onSuccess)
		{
			return AjaxOptionsHelper(
				null,
				httpMethod,
				onBegin,
				onComplete,
				onFailure,
				onSuccess
			);
		}

		/// <summary>
		/// 解析処理を実行するためのオプション設定を作成します。
		/// </summary>
		/// <typeparam name="TModel">モデルの型</typeparam>
		/// <param name="ajaxHelper">AJAX を使用した HTML マークアップの表示に使用される <see cref="AjaxHelper"/> オブジェクト</param>
		/// <returns>AJAX スクリプトを実行するためのオプション設定</returns>
		public static AjaxOptions CreateAjaxOptionsAnalyze<TModel>(this AjaxHelper<TModel> ajaxHelper)
		{
			return CreateAjaxOptions(ajaxHelper, onSuccess: "PROTOTYPE.ajax.onSuccessAnalyzable");
		}

		/// <summary>
		/// AJAX スクリプトを実行するためのオプション設定を作成します。
		/// </summary>
		/// <param name="confirm">要求が送信される前に確認ウィンドウに表示するメッセージ</param>
		/// <param name="httpMethod">HTTP 要求メソッド ("Get" または "Post")</param>
		/// <param name="onBegin">ページが更新される直前に呼び出される JavaScript 関数の名前</param>
		/// <param name="onComplete">応答データがインスタンス化された後、ページが更新される前に呼び出される JavaScript 関数</param>
		/// <param name="onFailure">ページの更新が失敗した場合に呼び出される JavaScript 関数</param>
		/// <param name="onSuccess">ページが正常に更新された後に呼び出される JavaScript 関数</param>
		/// <returns>AJAX スクリプトを実行するためのオプション設定</returns>
		private static AjaxOptions AjaxOptionsHelper(string confirm, string httpMethod, string onBegin, string onComplete, string onFailure, string onSuccess)
		{
			return new AjaxOptions
			{
				Confirm = confirm,
				HttpMethod = httpMethod,
				OnBegin = onBegin,
				OnComplete = onComplete,
				OnFailure = onFailure,
				OnSuccess = onSuccess,
			};
		}
	}
}