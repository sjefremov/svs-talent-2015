using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Registar.DomainModel;
using Registar.DomainModel.Interfaces;


namespace Registar.DataLayer
{
    public class RegistarDbContext:DbContext,IDataContext
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

        public IDbSet<TEntity> GetIDBSet<TEntity>() where TEntity : class, IsEntity
        {
            if (typeof(TEntity)==typeof(Bike))
            {
                return this.Bikes as IDbSet<TEntity>;
            }
            if (typeof(TEntity)==typeof(User))
            {
                return this.Users as IDbSet<TEntity>;
            }
            return null;
        }
    }
}
