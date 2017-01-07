using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AspDotNetDemo.Models
{
    /// <summary>
    /// アプリケーションのデータベースコンテキスト。
    /// </summary>
    public class AppContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
