using AspDotNetDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetDemo.Services
{
    /// <summary>
    /// ユーザの業務ロジックのインターフェイス。
    /// </summary>
    public interface IUserService
    {
    }

    /// <summary>
    /// ユーザの業務ロジック。
    /// </summary>
    public class UserService : IUserService, IDisposable
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public UserService()
        {
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
        /// <returns>ユーザ情報</returns>
        public User Exists(User condition)
        {
            using (var db = new DemoContext())
            {
                var userInfo = (
                    from x in db.Users
                    where x.UserId == condition.UserId && x.Password == condition.Password
                    select x
                ).FirstOrDefault();

                if (userInfo == null)
                {
                    throw new Exception("ユーザIDまたはパスワードが不正です。");
                }
                return userInfo;
            }
        }
    }
}