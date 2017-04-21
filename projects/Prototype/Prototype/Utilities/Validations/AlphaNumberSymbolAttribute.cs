using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティの値が半角英数記号であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AlphaNumberSymbolAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AlphaNumberSymbolAttribute() : base(@"[a-zA-Z0-9 -/:-@\[-\`\{-\~]+")
        {
        }
    }

    /// <summary>
    /// 半角英数記号属性のアダプタを提供します。
    /// </summary>
    public class AlphaNumberSymbolAttributeAdapter : DataAnnotationsModelValidator<AlphaNumberSymbolAttribute>
    {
        public AlphaNumberSymbolAttributeAdapter(ModelMetadata metadata, ControllerContext context, AlphaNumberSymbolAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS008";
            attribute.ErrorMessage = null;
        }
    }
}