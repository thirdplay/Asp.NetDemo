using Prototype.Validations.DataAnnotations;
using DataAnnotationsModelValidatorProvider = System.Web.Mvc.DataAnnotationsModelValidatorProvider;

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
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(RequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinLengthAttribute), typeof(MinLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MaxLengthAttribute), typeof(MaxLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinByteAttribute), typeof(MinByteAttributeAdapter));
        }
    }
}