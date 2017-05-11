using System;
using System.Text.RegularExpressions;

namespace Prototype.Mvc.Validations
{
	/// <summary>
	/// プロパティの値が指定した正規表現と一致する必要があることを指定します。
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RegularExpressionAttribute : ValidationAttributeBase
	{
		/// <summary>
		/// 使用する正規表現のパターン
		/// </summary>
		public string Pattern { get; private set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public RegularExpressionAttribute(string pattern)
		{
			this.Pattern = pattern;
		}

		/// <summary>
		/// プロパティの値が半角英語であることを確認します。
		/// </summary>
		/// <param name="value">検証するプロパティの値</param>
		/// <returns>検証要求の結果</returns>
		protected override bool IsValidCore(object value)
		{
			// 値が null または空の場合、チェック対象外
			string stringValue = value as string;
			if (string.IsNullOrEmpty(stringValue))
			{
				return true;
			}

			// 正規表現チェック
			var regex = new Regex(Pattern);
			Match m = regex.Match(stringValue);
			return (m.Success && m.Index == 0 && m.Length == stringValue.Length);
		}
	}
}