using System;
using System.Text;

namespace Prototype.Mvc.Validations
{
    /// <summary>
    /// プロパティで許容される最大byte数を指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MaxByteAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        /// <summary>
        /// 許容される最大byte数を取得します。
        /// </summary>
        public int Byte { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="@byte">許容される最大byte数</param>
        public MaxByteAttribute(int @byte) : base()
        {
            this.Byte = @byte;
        }

        /// <summary>
        /// 指定したエラーメッセージに書式を適用します
        /// </summary>
        /// <param name="name">書式設定された文字列に含まれる名前</param>
        /// <returns>許容される最大byte数を説明する文字列</returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Byte);
        }

        /// <summary>
        /// プロパティが最大byte数未満でないことを確認します。
        /// </summary>
        /// <param name="value">検証するプロパティの値</param>
        /// <returns>検証が成功した場合はtrue、それ以外の場合はfalse</returns>
        public override bool IsValid(object value)
        {
            var @byte = 0;

            if (value == null)
            {
                return true;
            }
            else if (value is string)
            {
                @byte = Encoding.UTF8.GetByteCount(value as string);
            }
            return @byte <= this.Byte;
        }
    }
}