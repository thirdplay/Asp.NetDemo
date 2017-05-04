using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prototype.ViewModels
{
    /// <summary>
    /// ViewModelの基底クラス。
    /// </summary>
    [Serializable]
    public class ViewModelBase : IValidatableObject
    {
        /// <summary>
        /// ボタン
        /// </summary>
        public string Button { get; set; }

        /// <summary>
        /// 指定したオブジェクトが有効かどうかを判断します。
        /// </summary>
        /// <param name="validationContext">検証コンテキスト</param>
        /// <returns>検証の失敗の情報を保持するコレクション</returns>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}