using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.BusinessLayer.Contracts
{
    public class BikeCreateResult:CommandResult
    {
        public bool IsSuccess { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
