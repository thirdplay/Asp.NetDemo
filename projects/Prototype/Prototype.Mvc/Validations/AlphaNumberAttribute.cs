using System;

namespace Prototype.Mvc.Validations
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
}