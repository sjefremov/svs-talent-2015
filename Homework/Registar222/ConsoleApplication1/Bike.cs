namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bike
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string RegNumber { get; set; }

        [StringLength(200)]
        public string Producer { get; set; }

        [StringLength(200)]
        public string Model { get; set; }

        [StringLength(200)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseDate { get; set; }

        [StringLength(200)]
        public string FrameMaterial { get; set; }

        public int? Gears { get; set; }

        [StringLength(200)]
        public string Colour { get; set; }

        [StringLength(200)]
        public string City { get; set; }

        [StringLength(200)]
        public string Status { get; set; }

        public long OwnerId { get; set; }
    }
}
