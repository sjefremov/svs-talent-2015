using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DomainModel
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public virtual IEnumerable<Bike> Bikes { get; set; }
    }
}
