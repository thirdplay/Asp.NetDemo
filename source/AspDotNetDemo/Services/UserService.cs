using AspDotNetDemo.Models;
using AspDotNetDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AspDotNetDemo.Services
{
    /// <summary>
    /// ユーザの業務ロジックのインターフェイス。
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// ユーザが存在するか判定します。
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <returns>ユーザ情報</returns>
        User Exists(User condition);

        /// <summary>
        /// すべてのユーザを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        IList<User> ListAll();
    }

    /// <summary>
    /// ユーザの業務ロジック。
    /// </summary>
    public class UserService : IUserService, IDisposable
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            System.Diagnostics.Debug.WriteLine("UserService:Constructor");
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("UserService:Dispose");
        }

        /// <summary>
        /// ユーザが存在するか判定します。
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <returns>ユーザ情報</returns>
        public User Exists(User condition)
        {
            var user = this._userRepository.Find(condition.UserId);
            if (user?.Password != condition.Password)
            {
                throw new Exception("ユーザIDまたはパスワードが不正です。");
            }
            return user;
        }

        /// <summary>
        /// すべてのユーザを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        public IList<User> ListAll()
        {
            return this._userRepository.ListAll();
        }
    }
}