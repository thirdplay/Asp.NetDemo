using System.ComponentModel.DataAnnotations;

namespace Prototype.ViewModels
{
    /// <summary>
    /// ログイン画面のViewModel。
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Required]
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }
    }
}