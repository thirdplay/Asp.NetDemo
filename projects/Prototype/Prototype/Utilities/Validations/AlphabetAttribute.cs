using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティの値が半角英語であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AlphabetAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AlphabetAttribute() : base(@"[a-zA-Z]+")
        {
        }
    }

    /// <summary>
    /// 半角英語属性のアダプタを提供します。
    /// </summary>
    public class AlphabetAttributeAdapter : DataAnnotationsModelValidator<AlphabetAttribute>
    {
        public AlphabetAttributeAdapter(ModelMetadata metadata, ControllerContext context, AlphabetAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS006";
            attribute.ErrorMessage = null;
        }
    }
}