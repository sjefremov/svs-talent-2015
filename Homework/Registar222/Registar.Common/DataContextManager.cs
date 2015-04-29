using Registar.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Common
{
    public static class DataContextManager
    {
        private static IDataContextFactory theFactory;

        public static TDataContext CreateContext<TDataContext>() //where TDataContext : IDataContext
        {
            TDataContext result = theFactory.CreateDataContext<TDataContext>();
            return result;
        }

        public static void RegisterFactory(IDataContextFactory factory)
        {
            theFactory = factory;
        }
    }
}
