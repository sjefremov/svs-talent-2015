using Registar.DomainModel;
using Registar.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registar.BusinessLayer.Contracts;

namespace Registar.Repository.Interfaces
{
    public interface IBikeRepository : IRepository
    {
        //IList<Bike> SearchBikes();
        //TODO Changing aboved method to this below
        IList<Bike> SearchBikes(BikeSearchCommand command);
    }
}
