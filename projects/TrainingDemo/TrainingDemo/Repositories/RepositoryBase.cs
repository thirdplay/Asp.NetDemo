using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// Repositoryパターンの機能を提供する基底クラス。
    /// </summary>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        /// <summary>
        /// データベースコンテキスト。
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// エンティティのコレクション。
        /// </summary>
        private readonly IDbSet<TEntity> _set;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">データベースコンテキスト</param>
        public RepositoryBase(DbContext context)
        {
            this._context = context;
            this._set = context.Set<TEntity>();
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
        }

        #region IRepository members

        /// <summary>
        /// 指定された主キー値を持つエンティティを検索します。
        /// </summary>
        /// <param name="keyValues">検索するエンティティの主キー値</param>
        /// <returns>検索されたエンティティ、または null</returns>
        public TEntity Find(params object[] keyValues)
        {
            return this._set.Find(keyValues);
        }

        /// <summary>
        /// すべてのエンティティを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        public IList<TEntity> ListAll()
        {
            return this._set.ToList();
        }

        /// <summary>
        /// 指定された述語によって定義された条件と一致するすべてのエンティティを取得します
        /// </summary>
        /// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数</param>
        /// <returns>エンティティのリスト</returns>
        public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this._set.Where(predicate).ToList();
        }

        /// <summary>
        /// 指定されたエンティティを、セットの基になるコンテキストに Added 状態で追加します。
        /// Added状態のエンティティは、Save が呼び出されたときにデータベースに挿入されます。
        /// </summary>
        /// <param name="entity">追加するエンティティ</param>
        public void Add(TEntity entity)
        {
            this._set.Add(entity);
        }

        /// <summary>
        /// 指定されたエンティティを Deleted としてマークします。
        /// Save が呼び出されたときにデータベースから削除されます。
        /// </summary>
        /// <param name="entity">削除するエンティティ</param>
        public void Remove(TEntity entity)
        {
            this._set.Remove(entity);
        }

        /// <summary>
        /// すべての変更を基になるデータベースに保存します。
        /// </summary>
        public void Save()
        {
            this._context.SaveChanges();
        }

        #endregion
    }
}