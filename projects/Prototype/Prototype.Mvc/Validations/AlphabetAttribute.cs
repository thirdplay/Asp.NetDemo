using System;

namespace Prototype.Mvc.Validations
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
}