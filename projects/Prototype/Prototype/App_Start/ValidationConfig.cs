using Prototype.Resources;
using Prototype.Mvc.Validations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ValidationAttribute = System.ComponentModel.DataAnnotations.ValidationAttribute;

namespace Prototype
{
	/// <summary>
	/// バリデーションの設定クラス。
	/// </summary>
	public class ValidationConfig
	{
		/// <summary>
		/// アダプターを登録します。
		/// </summary>
		public static void RegisterAdapter()
		{
			DataAnnotationsModelValidatorProvider.RegisterDefaultAdapter(typeof(ValidationAttributeAdapter));
		}
	}

	/// <summary>
	/// 入力検証属性のアダプタを提供します。
	/// </summary>
	public class ValidationAttributeAdapter : DataAnnotationsModelValidator
	{
		/// <summary>
		/// 入力検証とメッセージコードの組み合わせを表す。
		/// </summary>
		private static readonly Dictionary<Type, string> validations = new Dictionary<Type, string>()
		{
			{typeof(RequiredAttribute), "MS001"},
			{typeof(MinLengthAttribute), "MS002"},
			{typeof(MaxLengthAttribute), "MS003"},
			{typeof(MinByteAttribute), "MS004"},
			{typeof(MaxByteAttribute), "MS005"},
			{typeof(AlphabetAttribute), "MS006"},
			{typeof(AlphaNumberAttribute), "MS007"},
			{typeof(AlphaNumberSymbolAttribute), "MS008"},
			{typeof(NumberAttribute), "MS010"},
		};

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="metadata">モデルのメタデータ</param>
		/// <param name="context">コントローラーのコンテキスト</param>
		/// <param name="attribute">対象の入力検証属性</param>
		public ValidationAttributeAdapter(ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute)
			: base(metadata, context, attribute)
		{
			var type = attribute.GetType();
			if (validations.ContainsKey(type))
			{
				attribute.ErrorMessageResourceType = typeof(Messages);
				attribute.ErrorMessageResourceName = validations[type];
				attribute.ErrorMessage = null;
			}
		}
	}
}