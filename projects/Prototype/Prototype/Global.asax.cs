using log4net;
using System.Reflection;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Prototype
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
    }
}