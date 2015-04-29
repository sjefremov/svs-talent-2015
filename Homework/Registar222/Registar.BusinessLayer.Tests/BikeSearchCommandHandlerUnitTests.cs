using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registar.Repository.Interfaces;
using Registar.Factory.Interfaces;
using System.Collections.Generic;
using Registar.DomainModel;
using Registar.BusinessLayer.Contracts;
using Registar.Factory;
using Registar.BusinessLayer.Handlers;

namespace Registar.BusinessLayer.Tests
{
    [TestClass]
    public class BikeSearchCommandHandlerUnitTests
    {
        [TestMethod]
        public void ExecuteCommand_SmokeTest_NoException_Test()
        {
            //setup
            RepositoryManager.RegisterFactory(new BikeRepoStubFactory());
            BikeSearchCommandHandler handler = new BikeSearchCommandHandler();
            BikeSearchCommand command = new BikeSearchCommand();
            //exercise
            BikeSearchResult result = handler.Execute(command) as BikeSearchResult;
            //verify
            Assert.IsNotNull(result, "SmokeTest expectes to return not null result!");
            //cleanup
            RepositoryManager.RegisterFactory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExecuteCommand_NullRepositoryFactory_ThrowsNullException_Test()
        {
            //setup
            RepositoryManager.RegisterFactory(null);
            BikeSearchCommandHandler handler = new BikeSearchCommandHandler();
            BikeSearchCommand command = new BikeSearchCommand();
            //exercise
            BikeSearchResult result = handler.Execute(command) as BikeSearchResult;
            //
            //Assert.IsNotNull(result);
        }


    }

    public class BikeRepoStub : IBikeRepository
    {

        public System.Collections.Generic.IList<DomainModel.Bike> SearchBikes(BikeSearchCommand command)
        {
            List<Bike> result = new List<Bike>();
            return result;
        }

        public System.Collections.Generic.IList<Registar.DomainModel.Bike> SearchBikes()
        {
            throw new NotImplementedException();
        }
    }

    public class BikeRepoStubFactory : IRepositoryFactory
    {

        public TRepository CreateRepository<TRepository>() where TRepository : IRepository
        {
            BikeRepoStub result = new BikeRepoStub();
            return (TRepository)(object)result;
        }
    }
}
