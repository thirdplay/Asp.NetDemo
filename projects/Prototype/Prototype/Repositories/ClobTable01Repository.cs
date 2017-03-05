using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Prototype.Entities;
using Dapper;
using Prototype.Attributes;

namespace Prototype.Repositories
{
    /// <summary>
    /// CLOBテーブルのリポジトリインターフェース。
    /// </summary>
    [Repository(typeof(ClobTable01Repository))]
    public interface IClobTable01Repository
    {
        /// <summary>
        /// CLOBテーブルのデータを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>CLOBテーブルのデータ</returns>
        ClobTable01 Find(string id);
    }

    /// <summary>
    /// CLOBテーブルのリポジトリ。
    /// </summary>
    public class ClobTable01Repository : RepositoryBase, IClobTable01Repository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="serviceLocator">サービスロケーター</param>
        public ClobTable01Repository(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// CLOBテーブルのデータを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>CLOBテーブルのデータ</returns>
        public ClobTable01 Find(string id)
        {
            return this.Connection.Query<ClobTable01>(
                "select * from CLOB_TABLE_01 where id = :Id",
                new { Id = id }
            ).FirstOrDefault();
        }
    }
}