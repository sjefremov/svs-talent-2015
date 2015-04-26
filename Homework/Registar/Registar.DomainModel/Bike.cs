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
    public class Bike
    {
        //[Key]
        public int BikeId { set; get; }

        [Required()]
        [StringLength(maximumLength:200)]
        public string RegNumber { set; get; }

        [StringLength(maximumLength: 200)]
        public string Producer { set; get; }

        [StringLength(maximumLength: 200)]
        public string Model { set; get; }

        [StringLength(maximumLength: 200)]
        public string Type { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime PurchaseDate { get; set; }

        [StringLength(maximumLength: 200)]
        public string FrameMaterial { get; set; }

        public int Gears { get; set; }

        [StringLength(maximumLength: 200)]
        public string Colour { set; get; }

        [StringLength(maximumLength: 200)]
        public string City { set; get; }

        //TODO Status property should be of enum type
        [StringLength(maximumLength: 200)]
        public string Status { get; set; }

        //TODO Owner of the bike. Class for owners should be created.

        [NotMapped]
        public Object IgnoreMe { set; get; }

        [Timestamp, NotMapped]
        public byte[] TimeStamp { set; get; }

        [NotMapped]
        //povrzuvame so tabela itn i ako sakame Bike so BikeHistory da ni pravi join vidi vo BikeSearchCommandHandler
        public IEnumerable<BikeHistory> History { set; get; }
    }
    //[Table("BikeHistory")]
    public class BikeHistory
    {
        public int BikeId { set; get; }
        public DateTime Date { set; get; }
    }
}
