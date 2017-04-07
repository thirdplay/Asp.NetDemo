using Prototype.Validations;
using System.ComponentModel;

namespace Prototype.ViewModels
{
    /// <summary>
    /// 入力検証画面のViewModel
    /// </summary>
    public class ValidationTestViewModel
    {
        /// <summary>
        /// 必須項目
        /// </summary>
        [Required]
        [DisplayName("必須項目")]
        public string RequiredItem { get; set; }

        /// <summary>
        /// 最小文字数項目
        /// </summary>
        [MinLength(2)]
        [DisplayName("最小文字数項目")]
        public string MinLengthItem { get; set; }

        /// <summary>
        /// 最大文字数項目
        /// </summary>
        [MaxLength(4)]
        [DisplayName("最大文字数項目")]
        public string MaxLengthItem { get; set; }

        /// <summary>
        /// 最小byte数項目
        /// </summary>
        [MinByte(4)]
        [DisplayName("最小byte数項目")]
        public string MinByteItem { get; set; }

        /// <summary>
        /// 最大byte数項目
        /// </summary>
        [MaxByte(2)]
        [DisplayName("最大byte数項目")]
        public string MaxByteItem { get; set; }

        /// <summary>
        /// 半角英語項目
        /// </summary>
        [Alphabet]
        [DisplayName("半角英語項目")]
        public string AlphabetItem { get; set; }

        /// <summary>
        /// ラジオ項目1
        /// </summary>
        [DisplayName("ラジオ項目1")]
        public string RadioItem1 { get; set; }
        [DisplayName("ラジオ項目2")]
        public string RadioItem2{ get; set; }
        [DisplayName("ラジオ項目3")]
        public string RadioItem3 { get; set; }
    }
}