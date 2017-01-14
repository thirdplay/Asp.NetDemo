using System.Collections.Generic;
using System.Linq;
using TrainingDemo.Models;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// ユーザ情報のリポジトリインターフェイス。
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 指定されたユーザIDを持つユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        User Find(string userId);

        /// <summary>
        /// すべてのユーザ情報を取得します。
        /// </summary>
        /// <returns>ユーザ情報の列挙子</returns>
        IEnumerable<User> ListAll();

        /// <summary>
        /// 指定されたユーザ情報を挿入します。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        void Insert(User user);

        /// <summary>
        /// 指定されたユーザ情報を更新します。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        void Update(User user);

        /// <summary>
        /// 指定されたユーザIDのユーザ情報を削除します。
        /// </summary>
        /// <param name="user">削除するユーザ情報</param>
        void Delete(string userId);
    }

    /// <summary>
    /// ユーザ情報のリポジトリクラス。
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">データベースコンテキスト</param>
        public UserRepository(AppContext context) : base(context)
        {
        }

        /// <summary>
        /// 指定されたユーザIDを持つユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        public User Find(string userId)
        {
            return this.Query<User>(
                @"SELECT * FROM USER_INFO WHERE USER_ID = @UserId",
                new { @UserId = userId }
            ).FirstOrDefault();
        }

        /// <summary>
        /// すべてのユーザ情報を取得します。
        /// </summary>
        /// <returns>ユーザ情報の列挙子</returns>
        public IEnumerable<User> ListAll()
        {
            return this.Query<User>(@"SELECT * FROM USER_INFO").ToList();
        }

        /// <summary>
        /// 指定されたユーザ情報を挿入します。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        public void Insert(User user)
        {
            this.Execute(
                @"INSERT INTO USER_INFO VALUES(@UserId, @Password, @FirstName, @LastName, @Sex, @PhoneNumber, @MailAddress)",
                new
                {
                    UserId = user.UserId,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Sex = user.Sex,
                    PhoneNumber = user.PhoneNumber,
                    MailAddress = user.MailAddress
                });
        }

        /// <summary>
        /// 指定されたユーザ情報を更新します。
        /// </summary>
        /// <param name="user">追加するユーザ情報</param>
        public void Update(User user)
        {
            this.Execute(
                @"UPDATE USER_INFO SET "
                + "USER_ID = @UserId"
                + ",PASSWORD = @Password"
                + ",FIRST_NAME = @FirstName"
                + ",LAST_NAME = @LastName"
                + ",SEX = @Sex"
                + ",PHONE_NUMBER = @PhoneNumber"
                + ",MAIL_ADDRESS = @MailAddress"
                + " WHERE USER_ID = @UserId",
                new
                {
                    UserId = user.UserId,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Sex = user.Sex,
                    PhoneNumber = user.PhoneNumber,
                    MailAddress = user.MailAddress
                });
        }

        /// <summary>
        /// 指定されたユーザIDのユーザ情報を削除します。
        /// </summary>
        /// <param name="user">削除するユーザ情報</param>
        public void Delete(string userId)
        {
            this.Execute(@"DELETE FROM USER_INFO WHERE USER_ID = @UserId", new { UserId = userId });
        }
    }
}