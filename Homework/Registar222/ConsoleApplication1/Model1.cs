namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BikeOwner> BikeOwners { get; set; }
        public virtual DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeOwner>()
                .HasMany(e => e.Bikes)
                .WithRequired(e => e.BikeOwner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bike>()
                .Property(e => e.TStamp)
                .IsFixedLength();
        }
    }
}
