using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティの値が半角数字であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NumberAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NumberAttribute() : base(@"[0-9]+")
        {
        }
    }

    /// <summary>
    /// 半角数字属性のアダプタを提供します。
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