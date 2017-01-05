using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AspDotNetDemo.Repositories
{
    /// <summary>
    /// リポジトリーパターンの機能を提供するインターフェイス。
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 指定された主キー値を持つエンティティを検索します。
        /// </summary>
        /// <param name="keyValues">検索するエンティティの主キー値</param>
        /// <returns>検索されたエンティティ、または null</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// すべてのエンティティを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        IList<TEntity> ListAll();

        /// <summary>
        /// 指定された述語によって定義された条件と一致するすべてのエンティティを取得します
        /// </summary>
        /// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数</param>
        /// <returns>エンティティのリスト</returns>
        IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 指定されたエンティティを、セットの基になるコンテキストに Added 状態で追加します。
        /// Added状態のエンティティは、Save が呼び出されたときにデータベースに挿入されます。
        /// </summary>
        /// <param name="entity">追加するエンティティ</param>
        void Add(TEntity entity);

        /// <summary>
        /// 指定されたエンティティを Deleted としてマークします。
        /// Save が呼び出されたときにデータベースから削除されます。
        /// </summary>
        /// <param name="entity">削除するエンティティ</param>
        void Remove(TEntity entity);

        /// <summary>
        /// すべての変更を基になるデータベースに保存します。
        /// </summary>
        void Save();
    }
}