﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspDotNetDemo.Models
{
    /// <summary>
    /// 性別を表す列挙型。
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男性。
        /// </summary>
        [Display(Name = "男性")]
        Male = 0,

        /// <summary>
        /// 女性。
        /// </summary>
        [Display(Name = "女性")]
        Female,

        /// <summary>
        /// その他。
        /// </summary>
        [Display(Name = "その他")]
        Other
    }
    public static class SexExt
    {
        /// <summary>
        /// 表示名を取得します。
        /// </summary>
        /// <param name="value">性別を表す列挙型</param>
        /// <returns>表示名</returns>
        public static string GetDisplayName(this Sex value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            return (attributes?.Length > 0)
                ? attributes[0].Name
                : value.ToString();
        }
    }

    /// <summary>
    /// ユーザ編集画面のViewModel。
    /// </summary>
    public class UserEditViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Required]
        [Display(Name = "ユーザID")]
        [StringLength(8)]
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        [Required]
        [Display(Name = "パスワード")]
        [DataType(DataType.Password)]
        [StringLength(10)]
        public string Password { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Required]
        [Display(Name = "姓")]
        [StringLength(16)]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Required]
        [Display(Name = "名")]
        [StringLength(16)]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Required]
        [Display(Name = "性別")]
        public Sex? Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [Display(Name = "電話番号")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [Display(Name = "メールアドレス")]
        [StringLength(64)]
        public string MailAddress { get; set; }
    }
}