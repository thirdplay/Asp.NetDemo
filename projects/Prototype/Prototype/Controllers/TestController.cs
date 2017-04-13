using log4net;
using OfficeOpenXml;
using Prototype.Services;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace Prototype.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// テストサービス。
        /// </summary>
        private readonly TestService testService;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="testService">テストサービス</param>
        public TestController(TestService testService, System.Data.Common.DbConnection connection)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            this.logger.Debug("TestController:Index");
            this.logger.Debug("TestController:Id=" + this.testService.TestComponent.Id);
            //this.testService.TestClob01();
            return View();
        }

        /// <summary>
        /// Excelを作成します。
        /// </summary>
        [HttpPost]
        public async Task<JsonResult> AjaxTest()
        {
            if (!this.Request.IsAjaxRequest()) throw new Exception();

            var fileName = await ExecuteAnalyze();
            return new JsonResult()
            {
                Data = new { FileName = fileName }
            };
        }
        private Task<string> ExecuteAnalyze()
        {
            return Task.Run(() =>
            {
#if false
                // Microsoft.Office.Interop.Excel
                var dirPath = this.Server.MapPath("/Common/Result");

                Excel.Application app = null;
                Excel.Workbooks workbooks = null;
                Excel.Workbook workbook = null;
                Excel.Sheets sheets = null;
                Excel.Worksheet sheet = null;
                Excel.Range cells = null;
                Excel.Range cell = null;
                try
                {
                    app = new Excel.Application();
                    app.DisplayAlerts = false;

                    // ブック作成
                    workbooks = app.Workbooks;
                    workbook = workbooks.Add();
                    //workbook = workbooks.Open(@"C:\Users\DefaultAppPool\test.xlsx");

                    // シート作成
                    sheets = workbook.Worksheets;
                    sheet = sheets.Add();

                    // セル設定
                    cells = sheet.Cells;
                    cell = cells[1, 1];
                    cell.Value = "Test!!";

                    // 出力
                    var fileName = "prototype_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    workbook.SaveAs(Path.Combine(dirPath, fileName));

                    return fileName;
                }
                finally
                {
                    app.Quit();
                    Marshal.FinalReleaseComObject(cell);
                    Marshal.FinalReleaseComObject(cells);
                    Marshal.FinalReleaseComObject(sheet);
                    Marshal.FinalReleaseComObject(sheets);
                    Marshal.FinalReleaseComObject(workbook);
                    Marshal.FinalReleaseComObject(workbooks);
                    Marshal.FinalReleaseComObject(app);
                }
#else
                // EEPlus
                var dirPath = this.Server.MapPath("/Common/Result");
                using (var excel = new ExcelPackage())
                using (var worksheet = excel.Workbook.Worksheets.Add("Prototype"))
                {
                    // フォント指定（列：1から5列、行1から10列なので、A1:E10を指す）
                    worksheet.Cells[1, 1, 10, 5].Style.Font.Name = "ＭＳ Ｐゴシック";

                    // フォントサイズ指定
                    worksheet.Cells[1, 1, 10, 5].Style.Font.Size = 10;

                    // 文字設定（A2セルを指す）
                    worksheet.Cells[2, 1].Value = "今日の売上！";

                    // セル結合（A2とB2,C2を結合）
                    worksheet.Cells[2, 1, 2, 3].Merge = true;

                    // センタリング
                    worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    // 太字
                    worksheet.Cells[2, 1].Style.Font.Bold = true;

                    // 文字色指定
                    worksheet.Cells[2, 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);

                    // 罫線
                    using (var list = worksheet.Cells[5, 1, 8, 4])
                    {
                        list.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        list.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        list.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        list.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }
                    using (var listheader = worksheet.Cells[5, 1, 5, 4])
                    {
                        // セル背景色
                        listheader.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        listheader.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                        listheader.Style.Font.Color.SetColor(System.Drawing.Color.White);

                        // 中央寄せ
                        listheader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    // 書式（Valueはobject型。数値をそのままセットすると書式も数値となる）
                    worksheet.Cells[5, 1].Value = "商品";
                    worksheet.Cells[5, 2].Value = "単価";
                    worksheet.Cells[5, 3].Value = "売上数";
                    worksheet.Cells[5, 4].Value = "合計";

                    worksheet.Cells[6, 1].Value = "りんご";
                    worksheet.Cells[6, 2].Value = 100;
                    worksheet.Cells[6, 3].Value = 25;

                    worksheet.Cells[7, 1].Value = "みかん";
                    worksheet.Cells[7, 2].Value = 90;
                    worksheet.Cells[7, 3].Value = 10;

                    worksheet.Cells[8, 1].Value = "ばなな";
                    worksheet.Cells[8, 2].Value = 120;
                    worksheet.Cells[8, 3].Value = 20;

                    worksheet.Cells[6, 2, 8, 3].Style.Numberformat.Format = "0.00";

                    // 計算式
                    worksheet.Cells[6, 4].Formula = "B6 * C6";
                    worksheet.Cells[7, 4].Formula = "B7 * C7";
                    worksheet.Cells[8, 4].Formula = "B8 * C8";

                    // 印刷設定            
                    worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    worksheet.PrinterSettings.FitToPage = true;
                    worksheet.PrinterSettings.FitToWidth = 1;
                    worksheet.PrinterSettings.FitToHeight = 0;

                    // 幅調整
                    worksheet.Cells.AutoFitColumns();
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells[1, 1].AutoFitColumns(10);
                    worksheet.Cells[1, 2].AutoFitColumns(20);
                    worksheet.Cells[1, 3].AutoFitColumns(10);
                    worksheet.Cells[1, 4].AutoFitColumns(10);

                    // グラフ
                    using (var chart = worksheet.Drawings.AddChart("グラフ", OfficeOpenXml.Drawing.Chart.eChartType.BarClustered))
                    {
                        chart.SetPosition(10, 0, 0, 0);
                        chart.SetSize(400, 400);
                        chart.Series.Add("D6:D8", "A6:A8");
                    }

                    // 画像設定
                    //using (var picture = worksheet.Drawings.AddPicture("画像", new FileInfo(Server.MapPath("~/Content/Images/sanwa.png"))))
                    //{
                    //    picture.SetPosition(33, 0, 0, 0);
                    //}

                    // ページヘッダ設定
                    worksheet.HeaderFooter.OddHeader.LeftAlignedText = "Excel出力";

                    // ページフッタ設定（ページ番号／総ページ数）
                    worksheet.HeaderFooter.OddFooter.RightAlignedText = $"{ExcelHeaderFooter.PageNumber} / {ExcelHeaderFooter.NumberOfPages}";

                    // ページフッタ幅
                    worksheet.PrinterSettings.FooterMargin = (decimal)(0.8 / 2.54);
                    worksheet.PrinterSettings.BottomMargin = (decimal)(1.5 / 2.54);

                    // ページサイズ
                    worksheet.PrinterSettings.PaperSize = ePaperSize.A4;

                    // 用紙内にサイズ調整
                    worksheet.PrinterSettings.FitToHeight = 1;
                    worksheet.PrinterSettings.FitToWidth = 1;

                    // 出力
                    var fileName = "prototype_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    excel.SaveAs(new FileInfo(Path.Combine(dirPath, fileName)));
                    //using (var ms = new MemoryStream())
                    //{
                    //    excel.SaveAs(ms);
                    //    return File(ms.ToArray(), "application/msexcel", "prototype.xlsx");
                    //}
                    return fileName;
                }
#endif
            });
        }
    }
}