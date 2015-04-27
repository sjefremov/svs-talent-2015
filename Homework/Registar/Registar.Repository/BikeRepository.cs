using Registar.DomainModel;
using Registar.DomainModel.Interfaces;
using Registar.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Repository
{
    internal class BikeRepository : IBikeRepository
    {
        public IList<DomainModel.Bike> SearchBikes()
        {
            using (var context = DataContextManager.CreateContext<IDataContext>())
            {
            }
        }
    }
}
