using Registar.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DataLayer
{
    public class BikeConfiguration:EntityTypeConfiguration<Bike>
    {
        public BikeConfiguration()
        {
            //if pimary key contains two columns we should do the the commented lines
            //this.ToTable("Bikes", "Data").HasKey(x=>new { Id=x.BikeId,Colour=x.Colour});

            this.ToTable("Bikes", "Data").HasKey(p => p.BikeId);
            this.Property(p => p.BikeId).HasColumnName("Id");
            //this.Ignore(p => p.IgnoreMe);
        }
    }
}
