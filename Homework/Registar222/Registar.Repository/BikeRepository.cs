using Registar.Common;
using Registar.DomainModel;
using Registar.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registar.DataLayer;

namespace Registar.Repository
{
    internal class BikeRepository : IBikeRepository
    {
        public IList<DomainModel.Bike> SearchBikes()
        {
            using (var context = DataContextManager.CreateContext<IDataContext>())
            {
                return context.GetIDBSet<Bike>().ToList();   
            }
        }
    }
}
