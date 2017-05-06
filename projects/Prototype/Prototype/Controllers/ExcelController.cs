using OfficeOpenXml;
using Prototype.Services;
using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// Excelへのアクセスを制御コントローラー。
    /// </summary>
    public class ExcelController : ControllerBase
    {
#if false
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ExcelFileのダウンロード。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Download(string fileName = "prototype.xlsx")
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException();
            }

            // 出力
            var dirPath = this.Server.MapPath("~/App_Data/Excel");
            using (var excel = new ExcelPackage(new FileInfo(Path.Combine(dirPath, fileName))))
            using (var ms = new MemoryStream())
            {
                excel.SaveAs(ms);
                return File(ms.ToArray(), "application/msexcel", fileName);
            }
        }
#endif
    }
}