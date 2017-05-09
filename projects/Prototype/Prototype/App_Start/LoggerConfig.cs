using NLog;
using NLog.Config;
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
            GlobalDiagnosticsContext.Set("outputdir", HostingEnvironment.MapPath("/Common/Logs"));
            LogManager.Configuration.Reload();
        }
    }
}