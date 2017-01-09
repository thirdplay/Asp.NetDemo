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
        /// ユーザID。
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        public string MailAddress { get; set; }
    }
}
