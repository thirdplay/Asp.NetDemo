using System.Collections.Generic;
using System.Data;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// リポジトリーパターンの機能を提供するインターフェイス。
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// SQLを実行し、<see cref="TEntity"/> ごとに型指定されたデータを返します。
        /// </summary>
        /// <typeparam name="TEntity">エンティティクラス</typeparam>
        /// <param name="sql">実行するSQL</param>
        /// <param name="param">SQLのパラメータ</param>
        /// <param name="transaction">トランザクション</param>
        /// <returns><seealso cref="TEntity"/>のデータのシーケンス。基本型（int、stringなど）が照会された場合は、最初の列のデータを返却します。</returns>
        IEnumerable<TEntity> Query<TEntity>(string sql, object param, IDbTransaction transaction) where TEntity : class;

        /// <summary>
        /// パラメータ化されたSQLを実行します。
        /// </summary>
        /// <param name="sql">実行するSQL</param>
        /// <param name="param">SQLのパラメータ</param>
        /// <param name="transaction">トランザクション</param>
        /// <returns>影響を受けた行数</returns>
        int Execute(string sql, object param, IDbTransaction transaction);
    }
}