using AspDotNetDemo.Models;
using System.Data.Entity.Migrations;

namespace AspDotNetDemo.Migrations
{
    /// <summary>
    /// 自動マイグレーションに関連する構成クラス。
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// 最新の移行へのアップグレード後に動作し、シード データを更新できるようにします。
        /// </summary>
        /// <param name="context">データベースコンテキスト。</param>
        protected override void Seed(AppContext context)
        {
            var user = new User()
            {
                UserId = "test",
                Password = "test",
                FirstName = "山田",
                LastName = "太郎",
                Sex = "1",
                PhoneNumber = "0311111111",
                MailAddress = "yamada@test.co.jp",
            };

            context.Users.AddOrUpdate(u => u.UserId, user);
        }
    }
}