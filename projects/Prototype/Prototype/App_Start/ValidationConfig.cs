using Prototype.Validations.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            System.Web.Mvc.DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(RequiredAttributeAdapter));
        }
    }
}