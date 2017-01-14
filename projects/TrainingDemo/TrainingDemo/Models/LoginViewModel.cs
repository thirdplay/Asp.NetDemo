using System.ComponentModel.DataAnnotations;

namespace TrainingDemo.Models
{
    /// <summary>
    /// ログイン画面のViewModel。
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        [Display(Name = "パスワード")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}