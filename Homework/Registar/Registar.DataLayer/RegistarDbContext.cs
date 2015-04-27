using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Registar.DomainModel;


namespace Registar.DataLayer
{
    public class RegistarDbContext:DbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        public DbSet<User> Users { get; set; }
        public RegistarDbContext() : base("BikeRegistarDb")
        {
            Bikes = this.Set<Bike>();
            Users = this.Set<User>();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Configurations.Add(new BikeConfiguration());
        //}
    }
}
