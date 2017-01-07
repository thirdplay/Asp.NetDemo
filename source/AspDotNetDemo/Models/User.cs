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
        [Display(Name = "���[�UID")]
        [StringLength(8)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "�p�X���[�h")]
        [DataType(DataType.Password)]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "��")]
        [StringLength(16)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "��")]
        [StringLength(16)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "����")]
        [StringLength(1)]
        public string Sex { get; set; }

        [Display(Name = "�d�b�ԍ�")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "���[���A�h���X")]
        [StringLength(64)]
        public string MailAddress { get; set; }
    }
}
