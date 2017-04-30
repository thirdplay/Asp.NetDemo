using Prototype.Mvc.Validations;
using System.ComponentModel;

namespace Prototype.ViewModels
{
    /// <summary>
    /// ログイン画面のViewModel。
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// ユーザID
        /// </summary>
        [Required]
        [DisplayName("ユーザID")]
        public string UserId { get; set; }
    }
}