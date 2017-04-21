using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティの値が半角英数であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AlphaNumberAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AlphaNumberAttribute() : base(@"[a-zA-Z0-9]+")
        {
        }
    }

    /// <summary>
    /// 半角英数属性のアダプタを提供します。
    /// </summary>
    public class AlphaNumberAttributeAdapter : DataAnnotationsModelValidator<AlphaNumberAttribute>
    {
        public AlphaNumberAttributeAdapter(ModelMetadata metadata, ControllerContext context, AlphaNumberAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS007";
            attribute.ErrorMessage = null;
        }
    }
}