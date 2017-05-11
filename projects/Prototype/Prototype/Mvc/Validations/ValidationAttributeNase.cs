using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prototype.Mvc.Validations
{
	/// <summary>
	/// 入力検証の基本クラス。
	/// </summary>
	public abstract class ValidationAttributeBase : ValidationAttribute
	{
		/// <summary>
		/// 入力検証が有効かどうか判断します。
		/// </summary>
		/// <param name="validationContext">検証操作に関するコンテキスト情報</param>
		/// <returns>有効な場合はtrue。無効な場合はfalse。</returns>
		protected bool IsEnabled(ValidationContext validationContext)
		{
			var attributes = validationContext.GetAttributes(typeof(ConditionalAttribute)) as ConditionalAttribute[];
			if (attributes.Any(x => !x.IsMatch(validationContext)))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 現在の検証属性に対して指定された値を検証します。
		/// </summary>
		/// <param name="value">検証するデータフィールド値</param>
		/// <param name="validationContext">検証操作に関するコンテキスト情報</param>
		/// <returns>検証要求の結果</returns>
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			// 入力検証の有効チェック
			if (!IsEnabled(validationContext))
			{
				return ValidationResult.Success;
			}

			// 入力検証の実行
			if (IsValidCore(value))
			{
				return ValidationResult.Success;
			}

			return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
		}

		/// <summary>
		/// 検証のコア処理。
		/// </summary>
		/// <param name="value">検証するデータフィールド値</param>
		/// <returns>検証要求の結果</returns>
		protected abstract bool IsValidCore(object value);
	}
}