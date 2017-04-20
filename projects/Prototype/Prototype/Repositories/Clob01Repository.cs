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
    /// CLOBテーブルのリポジトリインターフェース。
    /// </summary>
    [Repository(typeof(Clob01Repository))]
    public interface IClob01Repository
    {
        /// <summary>
        /// CLOBテーブルのデータを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>CLOBテーブルのデータ</returns>
        Clob01 Find(string id);
    }

    /// <summary>
    /// CLOBテーブルのリポジトリ。
    /// </summary>
    public class Clob01Repository : RepositoryBase, IClob01Repository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="serviceLocator">サービスロケーター</param>
        public Clob01Repository(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>
        /// CLOBテーブルのデータを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>CLOBテーブルのデータ</returns>
        public Clob01 Find(string id)
        {
            return this.Connection.Query<Clob01>(
                "select * from CLOB_01 where id = :Id",
                new { Id = id }
            ).FirstOrDefault();
        }
    }
}