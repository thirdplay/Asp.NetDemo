using TrainingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// ユーザ情報のリポジトリインターフェイス。
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }

    /// <summary>
    /// ユーザ情報のリポジトリクラス。
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">データベースコンテキスト</param>
        public UserRepository(Models.AppContext context) : base(context)
        {
        }
    }
}