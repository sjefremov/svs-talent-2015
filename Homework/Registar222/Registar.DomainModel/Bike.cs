using Registar.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DomainModel
{
    [Table(name:"Bikes")]
    public class Bike:IsEntity
    {
        //[Key]
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

        public long UserId { get; set; }

        //TODO This is commented because it causes problems when displaying results for bikes because of lazy loading.
        //public virtual User User { get; set; }

        //[NotMapped]
        //public Object IgnoreMe { set; get; }

        //[Timestamp, NotMapped]
        //public byte[] TimeStamp { set; get; }

        //[NotMapped]
        //povrzuvame so tabela itn i ako sakame Bike so BikeHistory da ni pravi join vidi vo BikeSearchCommandHandler
        //public IEnumerable<BikeHistory> History { set; get; }
    }
    //[Table("BikeHistory")]
    //public class BikeHistory
    //{
    //    public int BikeId { set; get; }
    //    public DateTime Date { set; get; }
    //}
}
