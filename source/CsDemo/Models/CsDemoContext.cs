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

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
