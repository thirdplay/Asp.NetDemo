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
        [DisplayName("REQUIRED")]
        public string RequiredItem { get; set; }

        /// <summary>
        /// 最小文字数項目
        /// </summary>
        [MinLength(2)]
        [DisplayName("MINLENGTH")]
        public string MinLengthItem { get; set; }

        /// <summary>
        /// 最大文字数項目
        /// </summary>
        [MaxLength(4)]
        [DisplayName("MAXLENGTH")]
        public string MaxLengthItem { get; set; }

        /// <summary>
        /// 最小最大文字数項目
        /// </summary>
        [MinLength(2)]
        [MaxLength(4)]
        [DisplayName("RANGE")]
        public string RangeItem { get; set; }

        /// <summary>
        /// 最小byte数項目
        /// </summary>
        [MinByte(4)]
        [DisplayName("MINBYTE")]
        public string MinByteItem { get; set; }
    }
}