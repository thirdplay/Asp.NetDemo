using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OracleDemo.Models
{
    /// <summary>
    /// アプリケーションのデータベースコンテキスト。
    /// </summary>
    public class AppContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //スキーマを指定（デフォルトではdbo）
            modelBuilder.HasDefaultSchema("DEMO");
        }
    }
}
