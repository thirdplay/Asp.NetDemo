using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Prototype.Extensions
{
    /// <summary>
    /// HTMLヘルパーの拡張機能を提供します。
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// メッセージ領域のHTMLマークアップを返します。
        /// </summary>
        /// <param name="htmlHelper">このメソッドによって拡張される HTML ヘルパー インスタンス</param>
        /// <param name="id">メッセージ領域のID</param>
        /// <returns>メッセージ領域を表す div 要素</returns>
        public static MvcHtmlString MessageArea(this HtmlHelper htmlHelper, string id = "messageArea")
        {
            var result = new StringBuilder();

            var tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttribute("style", "display:none;");
            tagBuilder.AddCssClass("alert alert-dismissible alert-danger");
            result.Append(tagBuilder.ToString());

            System.Diagnostics.Debug.WriteLine(result.ToString());
            return MvcHtmlString.Create(result.ToString());
        }
    }
}