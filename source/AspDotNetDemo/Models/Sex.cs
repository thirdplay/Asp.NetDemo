using System;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetDemo.Models
{
    /// <summary>
    /// 性別を表す列挙型。
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男性。
        /// </summary>
        [Display(Name = "男性")]
        Male = 0,

        /// <summary>
        /// 女性。
        /// </summary>
        [Display(Name = "女性")]
        Female,

        /// <summary>
        /// その他。
        /// </summary>
        [Display(Name = "その他")]
        Other
    }

    /// <summary>
    /// 性別を表す列挙体の拡張クラス。
    /// </summary>
    public static class SexExt
    {
        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        /// <param name="value">性別を表す値</param>
        /// <returns>表示名</returns>
        public static string GetDisplayName(string value)
        {
            Sex result;
            return (Enum.TryParse(value, out result))
                ? result.GetDisplayName()
                : "";
        }

        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        /// <param name="value">性別を表す列挙体</param>
        /// <returns>表示名</returns>
        public static string GetDisplayName(this Sex value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            return (attributes?.Length > 0)
                ? attributes[0].Name
                : value.ToString();
        }
    }
}