using Prototype.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prototype.Mvc.Validations
{
	/// <summary>
	/// 入力検証の条件を表す属性。
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class ConditionalAttribute : Attribute
	{
		/// <summary>
		/// 対象のプロパティ名。
		/// </summary>
		private string propertyName;

		/// <summary>
		/// 条件を満たす値。
		/// </summary>
		private object value;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="propertyName">対象のプロパティ名</param>
		/// <param name="value">条件を満たす値</param>
		public ConditionalAttribute(string propertyName, object value)
		{
			this.propertyName = propertyName;
			this.value = value;
		}

		/// <summary>
		/// 入力検証が条件を満たすかどうかチェックします。
		/// </summary>
		/// <param name="validationContext">検証操作に関するコンテキスト情報</param>
		/// <returns>有効の場合はtrue。それ以外の場合はfalse。</returns>
		public bool IsMatch(ValidationContext validationContext)
		{
			var model = validationContext.ObjectInstance;
			var propertyValue = model.GetPropertyValue(propertyName);

			return propertyValue.Equals(value);
		}
	}
}