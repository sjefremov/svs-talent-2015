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
        //public IList<DomainModel.Bike> SearchBikes()
        //{
        //    using (var context = DataContextManager.CreateContext<IDataContext>())
        //    {
        //        return context.GetIDBSet<Bike>().ToList();   
        //    }
        //}

        public IList<Bike> SearchBikes(BusinessLayer.Contracts.BikeSearchCommand command)
        {
            using (var context = DataContextManager.CreateContext<IDataContext>())
            {
                var qry =
                    from b in context.GetIDBSet<Bike>()
                    select b;

                if (!string.IsNullOrEmpty(command.Colour))
                {
                    qry = qry.Where(x => x.Colour == command.Colour);
                }
                if (!string.IsNullOrEmpty(command.Producer))
                {
                    qry = qry.Where(x => x.Producer == command.Producer);
                }
                //
                int take;
                int skip;
                CalculateTakeSkip(command.PageSize, command.PageIndex, out take, out skip);
                qry = qry.OrderBy(x => x.Id).Take(take).Skip(skip);

                return qry.ToList();
            }
        }
        private void CalculateTakeSkip(int pageSize, int pageIndex, out int take, out int skip)
        {
            skip = 0;
            if (pageSize == 0)
                pageSize = 25;
            take = pageSize;
            if (pageIndex != 0)
                skip = (pageIndex - 1) * take;
        }


        public void CreateBike(BusinessLayer.Contracts.BikeCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
