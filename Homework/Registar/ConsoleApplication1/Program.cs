﻿using System;
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
using NLog;
using Ninject;
using System.Reflection;

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
            //Console.ReadLine();
            /*
    * Welcome to this NLog demo
    */
            //Console.Out.WriteLine("Greetings, some loggings is about to take place.");
            //Console.Out.WriteLine("");

            ///*
            // * This creates your logger. 
            // * Notice that in the config file we defined that everything should go into the file.
            // * (and if you set the console, it'll output to it as well).
            // */
            //Logger logger = LogManager.GetCurrentClassLogger();

            //Console.Out.WriteLine("Let's assume you're going to work, and using the bus to get there:");
            //Console.Out.WriteLine("------------------------------------------------------------------");
            //logger.Trace("Trace: The chatter of people on the street");
            //logger.Debug("Debug: Where are you going and why?");
            //logger.Info("Info: What bus station you're at.");
            //logger.Warn("Warn: You're playing on the phone and not looking up for your bus");
            //logger.Error("Error: You get on the wrong bus.");
            //logger.Fatal("Fatal: You are run over by the bus.");

            ///*
            // * Closing app
            // */
            //Console.Out.WriteLine("");
            //Console.Out.WriteLine("Done logging.");

            //Ninject.IKernel kernal = new StandardKernel();
            //kernal.Bind<IWeapon>().To<Ninja>();
            //var instance = kernal.Get<sourav>();
            //instance.Attack();
            //Console.ReadLine(); 
            Console.Out.WriteLine("Hit any key to exit");
            Console.ReadKey();
        }
    }
}
