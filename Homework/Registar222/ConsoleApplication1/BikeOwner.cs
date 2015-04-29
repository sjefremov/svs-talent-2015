namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("data.BikeOwners")]
    public partial class BikeOwner
    {
        public BikeOwner()
        {
            Bikes = new HashSet<Bike>();
        }

        public int BikeOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
