using System.IO;
using System.Web.Hosting;

namespace Prototype
{
    /// <summary>
    /// ロガーの設定クラス。
    /// </summary>
    public class LoggerConfig
    {
        /// <summary>
        /// ロガーを登録します。
        /// </summary>
        public static void RegisterLoggers()
        {
            log4net.GlobalContext.Properties["outputDir"] = @"D:\git\AspDotNetDemo\projects\Prototype\Commmon\Logs";//HostingEnvironment.MapPath("/Common/Logs");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(@"D:\git\AspDotNetDemo\projects\Prototype\Prototype\log4net.config"));
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(HostingEnvironment.MapPath("~/log4net.config")));
        }
    }
}