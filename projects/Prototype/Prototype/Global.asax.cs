using System;
using System.Net;
using System.Web;
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

            MvcHandler.DisableMvcResponseHeader = true;
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                var ex = Server.GetLastError();
                if (ex != null)
                {
                    if (ex is HttpException &&
                        ((HttpException)ex).GetHttpCode() == (int)HttpStatusCode.NotFound)
                    {
                        // NotFoundを相手にするとログが大変になるので無視
                        return;
                    }

                    // CustomErrorが無効な場合は、Controller内でおきた例外が二重にログ出力されてしまうことに注意。
                    // CustomErrorが有効な場合は、Controller外でおきた例外のみここでログ出力される。
                    try
                    {
                        //LogUtil.LogError(ex, HttpContext.Current);
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                    catch (Exception)
                    {
                        //LogUtil.LogErrorSimple(ex);
                    }
                }
            }
        }
    }
}