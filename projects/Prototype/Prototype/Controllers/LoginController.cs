//#define LOG4NET

using log4net;
using Prototype.Constants;
using Prototype.ViewModels;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;

namespace Prototype.Controllers
{
    /// <summary>
    /// ログイン画面のコントローラー。
    /// </summary>
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
#if LOG4NET
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
#else
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
#endif

        /// <summary>
        /// 初期表示アクション。
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Index(LoginViewModel model)
        {
            //#if DEBUG
            //            var hostName = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;
            //            model.UserId = "a" + Regex.Replace(hostName, @"[^0-9]", "").Substring(3, 7);
            //#endif
            //System.Diagnostics.Debug.WriteLine("UserId:" + this.HttpContext.Session["UserId"]);
            //System.Diagnostics.Debug.WriteLine("UrlReferrer:" + this.HttpContext.Request.UrlReferrer);
            //System.Diagnostics.Debug.WriteLine("ReturnUrl:" + this.HttpContext.Request.Params.Get("ReturnUrl"));

            int tStartTimeMillis = System.Environment.TickCount;
            using (new Tracer("Trace"))
            {
                Logger.Info("fib(25) = " + fib(25));
            }
            int tEndTimeMillis = System.Environment.TickCount;
            Debug.WriteLine("time: " + (tEndTimeMillis - tStartTimeMillis) + "ms");

            return View(model);
        }

        private static long fib(long n)
        {
            using (new Tracer("Trace"))
            {
                if (n <= 1)
                {
                    return 1;
                }
                return fib(n - 2) + fib(n - 1);
            }
        }

        /// <summary>
        /// ログイン。
        /// </summary>
        /// <param name="model">ログインViewModel</param>
        /// <returns>アクション結果</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            // ログイン処理
            FormsAuthentication.SetAuthCookie(model.UserId, false);
            this.HttpContext.Session[SessionKey.UserId] = model.UserId;

            return new JsonResult()
            {
                Data = new { Result = true }
            };
        }

        /// <summary>
        /// ログアウト。
        /// </summary>
        /// <returns>アクション結果</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            // ログアウト処理
            FormsAuthentication.SignOut();
            this.HttpContext.Session.RemoveAll();

            return RedirectToAction("Index");
        }
    }

    internal class Tracer : IDisposable
    {
#if LOG4NET
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
#else
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
#endif
        private Stopwatch mStopwatch;
        private long mStartTicks;

        public Tracer(string aCategory)
        {
            if (Logger.IsInfoEnabled)
            {
                if (Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
                {
                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                }
                Trace.CorrelationManager.StartLogicalOperation(aCategory);
                mStopwatch = Stopwatch.StartNew();
                mStartTicks = Stopwatch.GetTimestamp();
                Logger.Info("Start " + aCategory + ": Activity '" + Trace.CorrelationManager.ActivityId + "' in method '" + GetExecutingMethodName() + "' at " + mStopwatch.ElapsedTicks + " ticks");
            }
        }

        public void Dispose()
        {
            if (Logger.IsInfoEnabled)
            {
                try
                {
                    long tEndTicks = Stopwatch.GetTimestamp();
                    long tElapsedMillis = mStopwatch.ElapsedMilliseconds;
                    Logger.Info("End " + Trace.CorrelationManager.LogicalOperationStack.Peek() + ": Activity '" + Trace.CorrelationManager.ActivityId + "' in method '" + GetExecutingMethodName() + "' at " + tEndTicks + " ticks (elapsed time: " + tElapsedMillis + " ms)");
                }
                finally
                {
                    Trace.CorrelationManager.StopLogicalOperation();
                }
            }
            GC.SuppressFinalize(this);
        }

        private string GetExecutingMethodName()
        {
            string tResult = "Unknown";
            StackTrace tStackTrace = new StackTrace(false);

            for (int i = 0; i < tStackTrace.FrameCount; i++)
            {
                MethodBase tMethod = tStackTrace.GetFrame(i).GetMethod();
                if (tMethod.DeclaringType != GetType())
                {
                    tResult = string.Concat(tMethod.DeclaringType.FullName, ".", tMethod.Name);
                    break;
                }
            }

            return tResult;
        }
    }
}