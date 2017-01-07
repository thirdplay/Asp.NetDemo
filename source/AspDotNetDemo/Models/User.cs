using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AspDotNetDemo.Models
{
    public class User
    {
        [Required]
        [Display(Name = "ユーザID")]
        [StringLength(8)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "パスワード")]
        [DataType(DataType.Password)]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "姓")]
        [StringLength(16)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "名")]
        [StringLength(16)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "性別")]
        [StringLength(1)]
        public string Sex { get; set; }

        [Display(Name = "電話番号")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "メールアドレス")]
        [StringLength(64)]
        public string MailAddress { get; set; }
    }
}
