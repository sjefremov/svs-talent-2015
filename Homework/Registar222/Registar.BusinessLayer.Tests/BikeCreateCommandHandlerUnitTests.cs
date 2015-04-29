using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registar.Common;
using Registar.BusinessLayer.Handlers;
using Registar.BusinessLayer.Contracts;
using Registar.Repository.Interfaces;
using Registar.Common.Interfaces;
using Registar.DomainModel;

namespace Registar.BusinessLayer.Tests
{
    /// <summary>
    /// Summary description for BikeCreateCommandHandlerUnitTests
    /// </summary>
    //TODO Check this class. Maybe its implementation is not finished.
    [TestClass]
    public class BikeCreateCommandHandlerUnitTests
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestMethod]
        public void ExecuteCommand_SmokeTest_NoException_Test()
        {
            RepositoryManager.RegisterFactory(null);
            BikeCreateCommandHandler handler = new BikeCreateCommandHandler();
            BikeCreateCommand command = new BikeCreateCommand();

            BikeCreateResult result = handler.Execute(command) as BikeCreateResult;
        }
        [TestMethod]
        public void ExecuteCommand_CreatingBikeWithNotExistingOwnerId_ValidationError_Test()
        {
            RepositoryManager.RegisterFactory(null);
            BikeCreateCommandHandler handler = new BikeCreateCommandHandler();
            BikeCreateCommand command = new BikeCreateCommand();
            command.BikeToRegister = new Bike();
            //not valid owner ids are negative numbers
            command.BikeToRegister.UserId = int.MinValue;
            BikeCreateResult result = handler.Execute(command) as BikeCreateResult;
            Assert.IsFalse(result.IsSuccess,"For not valid ownerId operation should be unsuccessful!");
            StringAssert.Contains(result.ValidationErrors[0],"not valid ownerid","For not valid owner id validation error is expected");
        }
        [TestMethod]
        public void ExecuteCommand_CreatingBikeWithNotExistingOwner_RepoSaveMethodCalled_Test()
        {
            RepositoryManager.RegisterFactory(null);
            BikeCreateCommandHandler handler = new BikeCreateCommandHandler();
            BikeCreateCommand command = new BikeCreateCommand();
            command.BikeToRegister = new Bike();
            //not valid owner ids are negative numbers
            command.BikeToRegister.UserId = int.MinValue;
            BikeCreateResult result = handler.Execute(command) as BikeCreateResult;
            Assert.IsTrue(BikeRepoSpyFactory.Spy.SpyVarSaveCalled,"");
            StringAssert.Contains(result.ValidationErrors[0], "not valid ownerid", "For not valid owner id validation error is expected");
            
        }
        //[ExpectedException=typeof(DuplicateRegNumberException)]
        [TestMethod]
        public void ExecuteCommand_CreatingBikeWithExistingRegNumber_ThwrowsDuplicateRegNumberException_Test()
        {
            RepositoryManager.RegisterFactory(null);
            BikeCreateCommandHandler handler = new BikeCreateCommandHandler();
            BikeCreateCommand command = new BikeCreateCommand();
            BikeCreateResult result = handler.Execute(command) as BikeCreateResult;
        }
        public class BikeRepoSpy:IBikeRepository
        {
            public bool SpyVarSaveCalled { get; set; }
            public System.Collections.Generic.IList<DomainModel.Bike> SearchBikes(BikeSearchCommand command)
            {
                List<Bike> result = new List<Bike>();
                return result;
            }


            public void CreateBike(BikeCreateCommand command)
            {
                this.SpyVarSaveCalled = true;
            }
        }

        public class BikeRepoSpyFactory:IRepositoryFactory
        {
            public static BikeRepoSpy Spy { get; set; }
            public TRepository CreateRepository<TRepository>() where TRepository : IRepository
            {
                BikeRepoSpy result = new BikeRepoSpy();
                return (TRepository) (object)result;
            }
        }
    }
}
