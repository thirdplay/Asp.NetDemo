using System.ComponentModel.DataAnnotations;

namespace AspDotNetDemo.Models
{
    public class User
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Key]
        [Required]
        [StringLength(8)]
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        [Required]
        [StringLength(10)]
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Required]
        [StringLength(16)]
        [Display(Name = "姓")]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Required]
        [StringLength(16)]
        [Display(Name = "名")]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Required]
        [StringLength(1)]
        [Display(Name = "性別")]
        public string Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [StringLength(11)]
        [Display(Name = "電話番号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [StringLength(64)]
        [Display(Name = "メールアドレス")]
        public string MailAddress { get; set; }
    }
}
