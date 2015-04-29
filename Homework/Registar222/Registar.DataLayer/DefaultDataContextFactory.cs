using Registar.DataLayer;
using Registar.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DataLayer
{
    public class DefaultDataContextFactory:IDataContextFactory
    {
        public TDataContext CreateDataContext<TDataContext>()// where TDataContext : IDataContext
        {
            if (typeof(TDataContext) == typeof(IDataContext))
            {
                return (TDataContext)(object)new RegistarDbContext();
            }
            return default(TDataContext);
        }
    }
}
