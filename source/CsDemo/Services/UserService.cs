using CsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsDemo.Services
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
        public USER_INFO Exists(USER_INFO condition)
        {
            using (var db = new CsDemoContext())
            {
                var userInfo = (from x in db.USER_INFO
                                where x.USER_ID == condition.USER_ID && x.PASSWORD == condition.PASSWORD
                                select x).FirstOrDefault();
                if (userInfo == null)
                {
                    throw new Exception("ユーザIDまたはパスワードが不正です。");
                }
                return userInfo;
            }
        }
    }
}