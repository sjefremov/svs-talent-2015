using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registar.DataLayer;
using Registar.DomainModel;
using Registar.BusinessLayer.Contracts;
using Registar.BusinessLayer;
using Registar.Repository;
using Registar.Factory;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new RegistarDbContextInverse())
            //{
            //    var count = context.Bikes.Count();
            //    Console.WriteLine(count);
            //    Console.ReadLine();
            //}

            //using (var context = new RegistarDbContext())
            //{
            //    Console.WriteLine(context.Database.Connection.ConnectionString);
            //    var count = context.Bikes.Count();                
            //    Console.WriteLine(count);
            //    Console.ReadLine();
            //}
            RepositoryManager.RegisterFactory(new DefaultRepositoryFactory());
            DataContextManager.RegisterFactory(new DefaultDataContextFactory());
            BikeSearchCommand _command = new BikeSearchCommand();
            BikeSearchResult _result = CommandInvoker.InvokeCommand<BikeSearchCommand, BikeSearchResult>(_command);
            Console.WriteLine(_result.Result);
            Console.ReadLine();
        }
    }
}
