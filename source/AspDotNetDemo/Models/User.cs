using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AspDotNetDemo.Models
{
    public class User
    {
        /// <summary>
        /// ���[�UID�B
        /// </summary>
        [Display(Name = "���[�UID")]
        public string UserId { get; set; }

        /// <summary>
        /// �p�X���[�h�B
        /// </summary>
        [Display(Name = "�p�X���[�h")]
        public string Password { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [Display(Name = "��")]
        public string FirstName { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        [Display(Name = "��")]
        public string LastName { get; set; }

        /// <summary>
        /// ���ʁB
        /// </summary>
        [Display(Name = "����")]
        public string Sex { get; set; }

        /// <summary>
        /// �d�b�ԍ��B
        /// </summary>
        [Display(Name = "�d�b�ԍ�")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ���[���A�h���X�B
        /// </summary>
        [Display(Name = "���[���A�h���X")]
        public string MailAddress { get; set; }
    }
}
