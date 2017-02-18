using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingDemo.Models
{
    /// <summary>
    /// ���[�U���B
    /// </summary>
    [Table("USER_INFO")]
    public class User
    {
        /// <summary>
        /// ���[�UID�B
        /// </summary>
        [Key]
        [StringLength(8)]
        [Display(Name = "���[�UID")]
        [Column("USER_ID")]
        public string UserId { get; set; }

        /// <summary>
        /// �p�X���[�h�B
        /// </summary>
        [StringLength(10)]
        [Display(Name = "�p�X���[�h")]
        [Column("PASSWORD")]
        public string Password { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [StringLength(16)]
        [Display(Name = "��")]
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [StringLength(16)]
        [Display(Name = "��")]
        [Column("LAST_NAME")]
        public string LastName { get; set; }

        /// <summary>
        /// ���ʁB
        /// </summary>
        [StringLength(1)]
        [Display(Name = "����")]
        [Column("SEX", TypeName = "char")]
        public string Sex { get; set; }

        /// <summary>
        /// �d�b�ԍ��B
        /// </summary>
        [StringLength(11)]
        [Display(Name = "�d�b�ԍ�")]
        [Column("PHONE_NUMBER")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ���[���A�h���X�B
        /// </summary>
        [StringLength(64)]
        [Display(Name = "���[���A�h���X")]
        [Column("MAIL_ADDRESS")]
        public string MailAddress { get; set; }
    }
}
