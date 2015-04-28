using Registar.DataLayer;
using Registar.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Factory
{
    public class DefaultDataContextFactory:IDataContextFactory
    {
        public TDataContext CreateDataContext<TDataContext>() where TDataContext : IDataContext
        {
            //TODO Problem: Can not Reference Register.DataLayer beacause this project is referenced from it
            if (typeof(TDataContext) == typeof(IDataContext))
            {
                return (TDataContext)(object)new RegistarDbContext();
            }
            //TODO Just for now we return this. May cause some problems. This statement returns null!
            return default(TDataContext);
        }
    }
}
