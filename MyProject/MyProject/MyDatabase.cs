namespace MyProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDatabase : DbContext
    {
        public MyDatabase()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<PATIENT> PATIENT { get; set; }
        public virtual DbSet<RECIPE> RECIPE { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<VISIT> VISIT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PATIENT>()
                .Property(e => e.GENDER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.HEIGHT)
                .HasPrecision(4, 1);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.WEIGHT)
                .HasPrecision(5, 2);
        }
    }
}
