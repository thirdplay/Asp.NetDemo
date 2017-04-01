using Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Validations.DataAnnotations
{
    /// <summary>
    /// データ フィールドの値が必須であることを指定します。
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

    public class RequiredAttributeAdapter : DataAnnotationsModelValidator<RequiredAttribute>
    {
        public RequiredAttributeAdapter(ModelMetadata metadata, System.Web.Mvc.ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS001";
            attribute.ErrorMessage = null;
        }
    }
}