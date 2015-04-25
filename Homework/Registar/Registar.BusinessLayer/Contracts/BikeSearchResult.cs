using Registar.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.BusinessLayer.Contracts
{
    public class BikeSearchResult:CommandResult
    {
        public List<Bike> Result { set; get; }

        public BikeSearchResult()
        {
            Result = new List<Bike>();
        }
    }
}
