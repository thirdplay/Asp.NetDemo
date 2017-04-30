using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Prototype.Entities;
using Dapper;
using Prototype.Mvc.Annotations;
using Prototype.Mvc;

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
            var list = new string[] { "TEST", "M_USER" }.ToList();
            var parameters = new DynamicParameters();
            return this.Connection.Query<int>(
                @"select count(*) from USER_TABLES where " +
                list.CreateDynamicCondition("TableName", x => @"TABLE_NAME = :" + x, "OR", ref parameters),
                parameters
            ).FirstOrDefault();
            //return this.Connection.Query<int>(
            //    @"select count(*) from USER_TABLES where " +
            //    string.Join(" OR ", list.Select((x, i) => @"TABLE_NAME = :TABLE_NAME" + i)),
            //    p
            //).FirstOrDefault();
            //return this.Connection.Query<int>(
            //    "select count(*) from USER_TABLES where TABLE_NAME = :Names",
            //    new { Names = new string[] { "Test", "M_USER" } }
            //).FirstOrDefault();
        }
    }
}