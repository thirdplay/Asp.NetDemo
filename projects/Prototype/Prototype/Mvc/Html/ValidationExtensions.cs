using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Prototype.Mvc.Html
{
	/// <summary>
	/// 入力検証の拡張機能を提供します。
	/// </summary>
	public static class ValidationExtensions
	{
		/// <summary>
		/// メッセージ領域のHTMLマークアップを返します。
		/// </summary>
		/// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
		/// <returns>メッセージ領域を表す div 要素</returns>
		public static MvcHtmlString MessageArea(this HtmlHelper htmlHelper)
		{
			var result = new StringBuilder();

			var tagBuilder = new TagBuilder("div");
			tagBuilder.MergeAttribute("id", "messageArea");
			tagBuilder.MergeAttribute("style", "display:none;");
			tagBuilder.AddCssClass("alert alert-dismissible alert-danger");
			result.Append(tagBuilder.ToString());

			return MvcHtmlString.Create(result.ToString());
		}

		/// <summary>
		/// 指定された式で表される各データ フィールドについて、検証エラーメッセージの HTML マークアップを返します。
		/// </summary>
		/// <typeparam name="TModel">モデルの型</typeparam>
		/// <typeparam name="TProperty">プロパティの型</typeparam>
		/// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
		/// <param name="expression">表示するプロパティを格納しているオブジェクトを識別する式</param>
		/// <returns>エラー メッセージを含む span 要素。</returns>
		public static MvcHtmlString ValidationFieldFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			var result = new StringBuilder();

			var tagBuilder = new TagBuilder("span");
			tagBuilder.AddCssClass("field-validation-valid text-danger");
			tagBuilder.MergeAttribute("data-valmsg-for", (expression.Body as MemberExpression)?.Member.Name);
			result.Append(tagBuilder.ToString());

			return MvcHtmlString.Create(result.ToString());
		}

		// TODO:必要に応じて復活させる
#if false
        /// <summary>
        /// セレクトボックスの選択中の項目のテキストについて、HTML マークアップを返します。
        /// </summary>
        /// <typeparam name="TModel">モデルの型</typeparam>
        /// <typeparam name="TProperty">プロパティの型</typeparam>
        /// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
        /// <param name="expression">表示するプロパティを格納しているオブジェクトを識別する式</param>
        /// <returns>セレクトボックス要素。</returns>
        public static MvcHtmlString DisplaySelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var value = metadata.Model.ToString();
            var selectList = (IEnumerable<SelectListItem>)htmlHelper.ViewData.Eval(name);

            return MvcHtmlString.Create(selectList.First(p => p.Value == value).Text);
        }
#endif
	}
}