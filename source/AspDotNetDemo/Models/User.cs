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
        public string UserId { get; set; }

        /// <summary>
        /// �p�X���[�h�B
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// ���B
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ���ʁB
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// �d�b�ԍ��B
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// ���[���A�h���X�B
        /// </summary>
        public string MailAddress { get; set; }
    }
}
