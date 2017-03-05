using Microsoft.Practices.ServiceLocation;
using System.Data.Common;

namespace Prototype.Repositories
{
    /// <summary>
    /// リポジトリの基底クラス。
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// サービスロケーター。
        /// </summary>
        private readonly IServiceLocator serviceLocator;

        /// <summary>
        /// DB接続を取得します。
        /// </summary>
        protected DbConnection Connection
        {
            get
            {
                return this.serviceLocator.GetInstance<DbConnection>();
            }
        }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="serviceLocator">サービスロケーター</param>
        public RepositoryBase(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }
    }
}