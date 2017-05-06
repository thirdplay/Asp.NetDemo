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
#if LOG4NET
            log4net.GlobalContext.Properties["outputDir"] = HostingEnvironment.MapPath("/Common/Logs");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(HostingEnvironment.MapPath("~/log4net.config")));
#else
            GlobalDiagnosticsContext.Set("outputdir", HostingEnvironment.MapPath("/Common/Logs"));
            LogManager.Configuration.Reload();
            //NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(HostingEnvironment.MapPath("~/nlog.config"));
#if DEBUG
            //Logger.Trace("LoggingRules.Count:" + LogManager.Configuration.LoggingRules.Count);
            //NLog.LogManager.Configuration.AddRuleForAllLevels("debugger");
            //var rule = new LoggingRule("*", NLog.LogManager.Configuration.FindTargetByName("debugger"));
            //NLog.LogManager.Configuration.LoggingRules.Insert(0, rule);

            //NLog.LogManager.Configuration.LoggingRules.RemoveAt(0);
            //LogManager.Configuration.RemoveTarget("debugger");

            //var rule = NLog.LogManager.Configuration.LoggingRules[0];
            //rule.EnableLoggingForLevels(LogLevel.Trace, LogLevel.Fatal);

            //.AddRuleForAllLevels(@"debugger");
            //<logger name="*" minlevel="Trace" writeTo="debugger" />
#endif

#endif
        }
    }
}