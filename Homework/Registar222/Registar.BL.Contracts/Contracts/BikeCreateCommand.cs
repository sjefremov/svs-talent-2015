using Registar.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.BusinessLayer.Contracts
{
    public class BikeCreateCommand:Command
    {
        public Bike BikeToRegister { get; set; }
    }
}
