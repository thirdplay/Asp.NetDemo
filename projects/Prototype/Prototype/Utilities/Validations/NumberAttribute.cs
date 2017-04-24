using Prototype.Resources;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティの値が数値であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NumberAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        /// <summary>
        /// 変換時に指定する数値スタイル
        /// </summary>
        private NumberStyles NumberStyles { get; } = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;

        /// <summary>
        /// 負の値が許可されるかどうかを示す値を取得または設定します。
        /// </summary>
        public bool AllowNegative { get; set; }

        /// <summary>
        /// 小数を許可されるかどうかを示す値を取得または設定します。
        /// </summary>
        public bool AllowDecimal { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NumberAttribute()
        {
        }

        /// <summary>
        /// オブジェクトの指定した値が有効かどうかを判断します。
        /// </summary>
        /// <param name="value">検証対象のオブジェクトの値</param>
        /// <returns>指定した値が無効である場合はtrue、それ以外の場合はfalse</returns>
        public override bool IsValid(object value)
        {
            var str = value as string;
            if (str != null)
            {
                // 負の値を許可していないかつ、"-"がある場合
                if (!this.AllowNegative && str.IndexOf("-") >= 0)
                {
                    return false;
                }
                // 小数を許可していないかつ、"."がある場合
                if (!this.AllowDecimal && str.IndexOf(".") >= 0)
                {
                    return false;
                }

                // 数値形式への変換
                Decimal result;
                if (!Decimal.TryParse(str, out result))
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 数値属性のアダプタを提供します。
    /// </summary>
    public class NumberAttributeAdapter : DataAnnotationsModelValidator<NumberAttribute>
    {
        public NumberAttributeAdapter(ModelMetadata metadata, ControllerContext context, NumberAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS010";
            attribute.ErrorMessage = null;
        }
    }
}