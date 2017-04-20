using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Prototype.Entities;
using Dapper;
using Prototype.Utilities.Annotations;

namespace Prototype.Repositories
{
    /// <summary>
    /// テスト用のリポジトリインターフェース。
    /// </summary>
    [Repository(typeof(TestRepository))]
    public interface ITestRepository
    {
        /// <summary>
        /// テーブルの件数を取得します。
        /// </summary>
        /// <returns>件数</returns>
        int CountTable();
    }

    /// <summary>
    /// テスト用のリポジトリ。
    /// </summary>
    public class TestRepository : RepositoryBase, ITestRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="serviceLocator">サービスロケーター</param>
        public TestRepository(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// テーブルの件数を取得します。
        /// </summary>
        /// <returns>件数</returns>
        public int CountTable()
        {
            return this.Connection.Query<int>(
                "select count(*) from USER_TABLES"
            ).FirstOrDefault();
        }
    }
}