using System;

namespace Prototype.Mvc.Validations
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
}