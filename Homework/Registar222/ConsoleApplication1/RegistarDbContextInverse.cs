namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RegistarDbContextInverse : DbContext
    {
        public RegistarDbContextInverse()
            : base("name=RegistarDbContextInverse")
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
