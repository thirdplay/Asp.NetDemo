using System.Web.Mvc;
using System.Web.Routing;

namespace Prototype
{
    /// <summary>
    /// ASP.NET ルート設定クラス。
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// ASP.NET ルートを登録します。
        /// </summary>
        /// <param name="routes">ルートコレクション</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Index" }
            );
        }
    }
}