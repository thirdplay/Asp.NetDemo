using Prototype.Utilities.Validations;
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
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MaxByteAttribute), typeof(MaxByteAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AlphabetAttribute), typeof(AlphabetAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AlphaNumberAttribute), typeof(AlphaNumberAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AlphaNumberSymbolAttribute), typeof(AlphaNumberSymbolAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(NumberAttribute), typeof(NumberAttributeAdapter));
        }
    }
}