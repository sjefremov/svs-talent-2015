using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Common.Interfaces
{
    public interface IDataContextFactory
    {
        //If we have problem because of need of referencing this project by Registar.DataLayer project we will remove the where clause and reference to that project from this
        TDataContext CreateDataContext<TDataContext>(); //where TDataContext : IDataContext;
    }
}
