using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace Prototype.Interop.Excel
{
    /// <summary>
    /// Excelアプリケーションを操作する機能を提供します。
    /// </summary>
    public class Application : IDisposable
    {
        private Microsoft.Office.Interop.Excel.Application application;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public Application(string fileName)
        {
            this.application = new Microsoft.Office.Interop.Excel.Application();
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            this.application.Quit();
            Marshal.FinalReleaseComObject(this.application);
        }
    }
}