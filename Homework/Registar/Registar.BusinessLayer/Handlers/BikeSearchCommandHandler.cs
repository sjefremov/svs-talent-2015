using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registar.BusinessLayer.Contracts;
using Registar.DataLayer;
using Registar.DomainModel;

namespace Registar.BusinessLayer.Handlers
{
    internal class BikeSearchCommandHandler:CommandHandlerBase<BikeSearchCommand,BikeSearchResult>
    {
        IDbContext context;
        public BikeSearchCommandHandler(IDbContext context)
        {
            this.context = context;
        }
        protected override BikeSearchResult ExecuteCommand(BikeSearchCommand command)
        {
            //ova se koristi za da koga ke zavrsi metodot da se zatvori konekcijata do bazata
            //TODO Maybe this will cause problems in the future because of disposing the field context. Check this!
            using (IDbContext context = this.context)
            {
                BikeSearchResult _result = new BikeSearchResult();
                //List<Bike> bikes = new List<Bike>();
                // ovde query to nema da se izvrsi i ako go izneseme nadvor ke nemame veke context i ke  padne programata,
                //dokolku imame ToList() duri togas ke se izvrsi
                // IEnumerable<Bike> bikes = new List<Bike>();
                // bikes = context.Bikes.OrderBy(p => p.BikeId).Take(10); //ToList()

                //so toa sto query e IEnumarable moze da mu lepime poveke f-cii i toa nema da se izvrsi dodeka ne povikame ToList na kraj 
                //pred da go napolnime _result

                //var query = from b in context.Bikes//.Include("BikeHistory") //LazyLoad, ova se konfigurira vo Context
                //            select b;
                //if (!string.IsNullOrEmpty(command.Colour))
                //{
                //    query = query.Where(x => x.Colour == command.Colour);
                //}
                //if (!string.IsNullOrEmpty(command.Producer))
                //{
                //    query = query.Where(x => x.Producer == command.Producer);
                //}

                //se zema od koja strana da se pocne i kolku tocaci da se zemat
                //query = query.OrderBy(x => x.BikeId).Skip(command.PageIndex * command.PageSize).Take(command.PageSize);

                //_result e napolnet so tocaci od query
                //_result.Result = query.ToList();


                //var bikes = context.Bikes.OrderBy(p => p.Id).Take(10).ToList();
                //_result e napolnet so bikes
                //var bikes = context.Bikes.ToList();
                var bikes = context.Set<Bike>();
                _result.Result = bikes.ToList();
                return _result;
            }
        }
    }
}
