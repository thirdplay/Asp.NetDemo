using log4net;
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
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // ビューエンジンをRazorViewEngineのみを有効化
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            // MVC応答ヘッダを無効化
            MvcHandler.DisableMvcResponseHeader = true;

            // CSRFトークンのクッキー名を変更
            AntiForgeryConfig.CookieName = "token";
        }
    }
}