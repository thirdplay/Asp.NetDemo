using Prototype.Validations.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Prototype.ViewModels
{
    /// <summary>
    /// 入力検証画面のViewModel
    /// </summary>
    public class ValidationTestViewModel
    {
        /// <summary>
        /// 必須項目
        /// </summary>
        [Required]
        [DisplayName("Required")]
        public string RequiredItem { get; set; }

        /// <summary>
        /// 文字数項目
        /// </summary>
        [DisplayName("MaxLength")]
        public string MaxLengthItem { get; set; }
    }
}