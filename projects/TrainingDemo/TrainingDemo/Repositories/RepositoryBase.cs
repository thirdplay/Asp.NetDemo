﻿using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.Common;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// Repositoryパターンの機能を提供する基底クラス。
    /// </summary>
    public abstract class RepositoryBase : IDisposable
    {
        /// <summary>
        /// データベースへの接続。
        /// </summary>
        private readonly DbConnection dbConnection;

        /// <summary>
        /// データベースへの接続を取得します。
        /// </summary>
        private IDbConnection Connection => this.dbConnection;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="dbConnection">データベースへの接続</param>
        public RepositoryBase(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// SQLを実行し、<see cref="TEntity"/> ごとに型指定されたデータを返します。
        /// </summary>
        /// <typeparam name="TEntity">エンティティクラス</typeparam>
        /// <param name="sql">実行するSQL</param>
        /// <param name="param">SQLのパラメータ</param>
        /// <param name="transaction">トランザクション</param>
        /// <returns><seealso cref="TEntity"/>のデータのシーケンス。基本型（int、stringなど）が照会された場合は、最初の列のデータを返却します。</returns>
        protected IEnumerable<TEntity> Query<TEntity>(string sql, object param = null, IDbTransaction transaction = null) where TEntity : class
        {
            return this.Connection.Query<TEntity>(sql, param, transaction);
        }

        /// <summary>
        /// パラメータ化されたSQLを実行します。
        /// </summary>
        /// <param name="sql">実行するSQL</param>
        /// <param name="param">SQLのパラメータ</param>
        /// <param name="transaction">トランザクション</param>
        /// <returns>影響を受けた行数</returns>
        protected int Execute(string sql, object param = null, IDbTransaction transaction = null)
        {
            return this.Connection.Execute(sql, param, transaction);
        }
    }
}