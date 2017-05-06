using NLog;
using System;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Prototype
{
    /// <summary>
    /// ASP.NET アプリケーションクラス。
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// ロギングインターフェース
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// アプリケーション開始処理。
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoggerConfig.RegisterLoggers();
            ValidationConfig.RegisterAdapter();

            // ビューエンジンをRazorViewEngineのみを有効化
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            // MVC応答ヘッダを無効化
            MvcHandler.DisableMvcResponseHeader = true;

            // CSRFトークンのクッキー名を変更
            AntiForgeryConfig.CookieName = "token";
        }

        /// <summary>
        /// アプリケーションの例外イベント。
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                var ex = Server.GetLastError();
                if (ex != null)
                {
                    if (ex is HttpException && ((HttpException)ex).GetHttpCode() == (int)HttpStatusCode.NotFound)
                    {
                        // NotFoundを相手にするとログが大変になるので無視
                        return;
                    }

                    // CustomErrorが無効な場合は、Controller内でおきた例外が二重にログ出力されてしまうことに注意。
                    // CustomErrorが有効な場合は、Controller外でおきた例外のみここでログ出力される。
                    logger.Error(ex);
                }
            }
        }
    }
}