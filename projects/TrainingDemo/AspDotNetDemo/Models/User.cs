using System.ComponentModel.DataAnnotations;

namespace AspDotNetDemo.Models
{
    public class User
    {
        /// <summary>
        /// ���[�UID�B
        /// </summary>
        [Key]
        [Required]
        [StringLength(8)]
        [Display(Name = "���[�UID")]
        public string UserId { get; set; }

        /// <summary>
        /// �p�X���[�h�B
        /// </summary>
        [Required]
        [StringLength(10)]
        [Display(Name = "�p�X���[�h")]
        public string Password { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [Required]
        [StringLength(16)]
        [Display(Name = "��")]
        public string FirstName { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [Required]
        [StringLength(16)]
        [Display(Name = "��")]
        public string LastName { get; set; }

        /// <summary>
        /// ���ʁB
        /// </summary>
        [Required]
        [StringLength(1)]
        [Display(Name = "����")]
        public string Sex { get; set; }

        /// <summary>
        /// �d�b�ԍ��B
        /// </summary>
        [StringLength(11)]
        [Display(Name = "�d�b�ԍ�")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ���[���A�h���X�B
        /// </summary>
        [StringLength(64)]
        [Display(Name = "���[���A�h���X")]
        public string MailAddress { get; set; }
    }
}
