namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("data.Bikes")]
    public partial class Bike
    {
        public int BikeId { get; set; }

        public int BikeOwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNumber { get; set; }

        [StringLength(20)]
        public string Colour { get; set; }

        [StringLength(50)]
        public string Producer { get; set; }

        [StringLength(20)]
        public string Model { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public byte? SpeedCount { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TStamp { get; set; }

        public virtual BikeOwner BikeOwner { get; set; }
    }
}
