using TrainingDemo.Models;
using TrainingDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrainingDemo.Services
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
        /// <returns>存在する場合はtrue、それ以外はfalseを返却します。</returns>
        bool Exists(User condition);

        /// <summary>
        /// 指定されたユーザIDのユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        User Find(string userId);

        /// <summary>
        /// すべてのユーザを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        List<User> ListAll();
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
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// ユーザが存在するか判定します。
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <returns>存在する場合はtrue、それ以外はfalseを返却します。</returns>
        public bool Exists(User condition)
        {
            var user = this._userRepository.Find(condition.UserId);
            if (user?.Password != condition.Password)
            {
                throw new Exception("ユーザIDまたはパスワードが不正です。");
            }
            return true;
        }

        /// <summary>
        /// 指定されたユーザIDのユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        public User Find(string userId)
        {
            return this._userRepository.Find(userId);
        }

        /// <summary>
        /// すべてのユーザを取得します。
        /// </summary>
        /// <returns>エンティティのリスト</returns>
        public List<User> ListAll()
        {
            return this._userRepository.ListAll();
        }
    }
}