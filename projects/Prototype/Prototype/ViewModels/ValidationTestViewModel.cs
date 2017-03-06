using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        /// ID
        /// </summary>
        [Required]
        [DisplayName("ID")]
        public string Id { get; set; }
    }
}