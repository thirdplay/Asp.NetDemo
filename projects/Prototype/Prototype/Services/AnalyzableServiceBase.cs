using log4net;
using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Constants;
using Prototype.Utilities.Annotations;
using Prototype.Entities;
using Prototype.Utilities.Interop;
using Prototype.Models;
using Prototype.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Prototype.Services
{
    /// <summary>
    /// テスト解析サービスのインターフェース。
    /// </summary>
    public interface IAnalyzableServiceBase
    {
        Task<string> Analyze(HttpContextBase httpContext);
    }

    /// <summary>
    /// 解析サービスの基底クラス。
    /// </summary>
    public abstract class AnalyzableServiceBase : IAnalyzableServiceBase, IDisposable
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        //protected virtual ILog Logger { get; } = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public AnalyzableServiceBase()
        {
            //this.Logger.Debug($"AnalyzableServiceBase:Constructor");
        }

        public Task<string> Analyze(HttpContextBase httpContext)
        {
            //// セッションに既にキャンセルトークンがある場合、処理を中断する
            //Debug.WriteLine("ThreadId:" + Thread.CurrentThread.ManagedThreadId);
            //Debug.WriteLine("SessionId:" + httpContext.Session.SessionID);
            //Debug.WriteLine("CancelToken:" + httpContext.Session["CancelToken"]);

            //// セッションにキャンセルトークンを登録する
            //var tokenSource = new CancellationTokenSource();
            //httpContext.Session["CancelToken"] =  tokenSource;
            //Debug.WriteLine("CancelToken:" + httpContext.Session["CancelToken"]);

            //var token = tokenSource.Token;
            return Task.Run(() =>
            {
                // InteropExcel
                var resultDir = HostingEnvironment.MapPath("/Common/Result");
                var tempDir = HostingEnvironment.MapPath("/Common/Template");
                using (var excel = new InteropExcel(Path.Combine(tempDir, "prototype.xlsm")))
                {
                    excel.Run("ThisWorkbook.TestMacro4", "a1", "a2");

                    // 出力
                    var fileName = "prototype_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsm";
                    excel.SaveAs(Path.Combine(resultDir, fileName));

                    return fileName;
                }
#if false
                try
                {
                    Debug.WriteLine("ThreadId:" + Thread.CurrentThread.ManagedThreadId);
                    Debug.WriteLine("SessionId:" + httpContext.Session.SessionID);
                    Debug.WriteLine("CancelToken:" + httpContext.Session["CancelToken"]);

                    Debug.WriteLine("Step1:Processing...");
                    Thread.Sleep(1000);
                    Debug.WriteLine("Step1:Completed");
                    token.ThrowIfCancellationRequested();

                    Debug.WriteLine("Step2:Processing...");
                    Thread.Sleep(1000);
                    Debug.WriteLine("Step2:Completed");
                    token.ThrowIfCancellationRequested();

                    Debug.WriteLine("Step3:Processing...");
                    Thread.Sleep(1000);
                    Debug.WriteLine("Step3:Completed");
                    token.ThrowIfCancellationRequested();

                    Debug.WriteLine("Step4:Processing...");
                    Thread.Sleep(1000);
                    Debug.WriteLine("Step4:Completed");
                    token.ThrowIfCancellationRequested();

                    return "test.xlsx";
                }
                catch
                {
                    Debug.WriteLine("Cancel!!");
                    return "";
                }
                finally
                {
                    //httpContext.Session.Remove("CancelToken");
                }
#endif
            });
        }

        //private string AnalyzeAction<TViewModel>(HttpContext httpContext, TViewModel viewModel, CancellationToken token)
        //{
        //    // キャンセル判定
        //    if (token.IsCancellationRequested) return "";

        //    // データ取得
        //    //var data = GetData(httpContext, viewModel);

        //    // データ解析
        //    //AnalyzeData(data);

        //    // 解析結果の作成
        //    //return CreateResult(data);

        //    return "";
        //}

        //protected abstract TResult GetData<TViewModel, TResult>(HttpContext httpContext, TViewModel viewModel);
        //protected abstract void AnalyzeData<TData>(TData data);
        //protected abstract string CreateResult<TData>(TData data);

#region IDispose members

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            //this.Logger.Debug("AnalyzableServiceBase:Dispose");
        }

#endregion
    }
}