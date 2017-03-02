using log4net;
using Oracle.ManagedDataAccess.Client;
using Prototype.Profilers;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System.Data.Common;
using System.Reflection;

namespace Prototype.Factories
{
    /// <summary>
    /// Oracleへの接続の生成機能を提供します。
    /// </summary>
    public static class OracleConnectionFactory
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 新しいOracleデータベースへの接続を作成します。
        /// </summary>
        /// <param name="connectionString">接続文字列</param>
        /// <returns>接続インスタンス</returns>
        public static DbConnection CreateConnection(string connectionString)
        {
            return new ProfiledDbConnection(new OracleConnection(connectionString),
                new CompositeDbProfiler(MiniProfiler.Current, new TraceDbProfiler()));
        }
    }
}