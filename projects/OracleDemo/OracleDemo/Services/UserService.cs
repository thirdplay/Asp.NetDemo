using OracleDemo.Models;
using OracleDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace OracleDemo.Services
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
        IList<User> ListAll();

        /// <summary>
        /// 指定されたユーザ情報を、セットの基になるコンテキストに Added 状態で追加します。
        /// Added状態のユーザ情報は、Save が呼び出されたときにデータベースに挿入されます。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        void Add(User user);

        /// <summary>
        /// 指定されたユーザ情報を Deleted としてマークします。
        /// Save が呼び出されたときにデータベースから削除されます。
        /// </summary>
        /// <param name="user">削除するユーザ情報</param>
        void Remove(User user);

        /// <summary>
        /// すべての変更をデータベースに保存します。
        /// </summary>
        void Save();
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
            Debug.WriteLine("UserService:Dispose");
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
        public IList<User> ListAll()
        {
            return this._userRepository.ListAll();
        }

        /// <summary>
        /// 指定されたユーザ情報を、セットの基になるコンテキストに Added 状態で追加します。
        /// Added状態のユーザ情報は、Save が呼び出されたときにデータベースに挿入されます。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        public void Add(User user)
        {
            this._userRepository.Add(user);
        }

        /// <summary>
        /// 指定されたユーザ情報を Deleted としてマークします。
        /// Save が呼び出されたときにデータベースから削除されます。
        /// </summary>
        /// <param name="user">削除するユーザ情報</param>
        public void Remove(User user)
        {
            this._userRepository.Remove(user);
        }

        /// <summary>
        /// すべての変更をデータベースに保存します。
        /// </summary>
        public void Save()
        {
            this._userRepository.Save();
        }
    }
}