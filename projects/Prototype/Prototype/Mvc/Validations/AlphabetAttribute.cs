using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Prototype.Mvc.Validations
{
	/// <summary>
	/// プロパティの値が半角英語であることを指定します。
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class AlphabetAttribute : RegularExpressionAttribute
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AlphabetAttribute() : base(@"[a-zA-Z]+")
		{
		}
	}
}