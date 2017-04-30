using System;

namespace Prototype.Mvc.Validations
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
}