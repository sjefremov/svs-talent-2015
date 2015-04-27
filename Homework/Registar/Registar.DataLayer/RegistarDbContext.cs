using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Registar.DomainModel;


namespace Registar.DataLayer
{
    public class RegistarDbContext:DbContext,IDbContext
    {
        public IDbSet<Bike> Bikes { get; set; }

        public IDbSet<User> Users { get; set; }
        public RegistarDbContext() : base("BikeRegistarDb")
        {
            Users = this.Set<User>();
            Bikes = this.Set<Bike>();
            
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Configurations.Add(new BikeConfiguration());
        //}

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class, IsEntity
        {
            return base.Set<TEntity>();  
        }
    }

    public interface IDbContext:IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class, IsEntity;  
        int SaveChanges();
    }
}
