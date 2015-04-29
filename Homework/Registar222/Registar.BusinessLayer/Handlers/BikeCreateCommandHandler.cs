using Registar.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registar.BusinessLayer.Handlers
{
    public class BikeCreateCommandHandler : CommandHandlerBase<BikeCreateCommand, BikeCreateResult>
    {
        protected override BikeCreateResult ExecuteCommand(BikeCreateCommand command)
        {
            BikeCreateResult result = new BikeCreateResult();

            return result;
        }
    }
}
