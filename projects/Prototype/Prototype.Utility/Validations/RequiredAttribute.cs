using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Validations
{
    /// <summary>
    /// プロパティの値が必須であることを指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RequiredAttribute() : base()
        {
        }
    }

    /// <summary>
    /// 必須属性のアダプタを提供します。
    /// </summary>
    public class RequiredAttributeAdapter : DataAnnotationsModelValidator<RequiredAttribute>
    {
        public RequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS001";
            attribute.ErrorMessage = null;
        }
    }
}