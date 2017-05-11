using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Prototype.Mvc.Html
{
	/// <summary>
	/// ラベル関連のHTML拡張機能を提供します。
	/// </summary>
	public static class LabelExtensions
	{
		/// <summary>
		/// 指定された式で表されるプロパティの HTML label 要素およびプロパティ名を返します。
		/// </summary>
		/// <typeparam name="TModel">モデルの型</typeparam>
		/// <typeparam name="TValue">値の型</typeparam>
		/// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
		/// <param name="expression">表示するプロパティを識別する式</param>
		/// <returns>式で表されるプロパティの HTML label 要素およびプロパティ名</returns>
		public static MvcHtmlString ItemLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
		{
			return LabelHelper(htmlHelper, ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData));
		}

		/// <summary>
		/// 指定された式で表されるプロパティの HTML label 要素およびプロパティ名を返します。
		/// </summary>
		/// <typeparam name="TModel">モデルの型</typeparam>
		/// <typeparam name="TValue">値の型</typeparam>
		/// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
		/// <param name="expression">表示するプロパティを識別する式</param>
		/// <param name="htmlAttributes">この要素に設定する HTML 属性を格納するオブジェクト</param>
		/// <returns>式で表されるプロパティの HTML label 要素およびプロパティ名</returns>
		public static MvcHtmlString ItemLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
		{
			return LabelHelper(
				htmlHelper,
				ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
				HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// 指定された <see cref="ModelMetadata"/> の HTML label 要素およびプロパティ名を返します。
		/// </summary>
		/// <param name="html">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
		/// <param name="metadata">この要素を表すメタデータ</param>
		/// <param name="htmlAttributes">この要素に設定する HTML 属性を格納するオブジェクト</param>
		/// <returns>HTML label 要素およびプロパティ名</returns>
		private static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, IDictionary<string, object> htmlAttributes = null)
		{
			string resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName;
			var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
			var tag = new TagBuilder("label");
			tag.SetInnerText(resolvedLabelText);
			tag.MergeAttributes(htmlAttributes, replaceExisting: true);

			return MvcHtmlString.Create(tag.ToString());
		}
	}
}