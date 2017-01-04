namespace CsDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CsDemoContext : DbContext
    {
        public CsDemoContext()
            : base("name=CsDemoContext")
        {
        }

        public virtual DbSet<USER_INFO> USER_INFO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USER_INFO>()
                .Property(e => e.SEX)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
