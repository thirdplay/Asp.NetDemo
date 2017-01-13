using OracleDemo.Models;

namespace OracleDemo.Repositories
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
        public UserRepository(AppContext context) : base(context)
        {
        }
    }
}