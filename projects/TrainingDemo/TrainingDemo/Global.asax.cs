using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrainingDemo.App_Start;

namespace TrainingDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            DapperConfig.RegisterMappings("TrainingDemo.Models");
        }
    }
}
