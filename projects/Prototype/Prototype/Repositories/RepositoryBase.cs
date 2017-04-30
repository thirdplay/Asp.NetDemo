using Dapper;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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