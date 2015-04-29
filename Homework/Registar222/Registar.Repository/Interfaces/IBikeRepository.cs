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
        IList<Bike> SearchBikes(BikeSearchCommand command);
        void CreateBike(BikeCreateCommand command);
    }
}
