using AtomosHyla.Core.Library;
using MES.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.BusinessLogic.Actions;
using MES.BusinessLogic.Library.Requests;

namespace MES.Test
{
    [TestClass]
    public class ActionsUnitTest
    {
        public IServiceProvider ServiceProvider { get; }
        public UnitOfWork UnitOfWork { get; }

        public ActionsUnitTest()
        {
            string loggerConfig = "log.config";
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(loggerConfig);

            ServiceProviderFactory.ServiceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddNLog().SetMinimumLevel(LogLevel.Trace);
            });

            ServiceProviderFactory.ServiceCollection.AddSingleton<IConfiguration>((provider) =>
                 new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build()
            );
            ServiceProvider = ServiceProviderFactory.BuildServiceProvider();
            UnitOfWork = new UnitOfWork(new DataContextFactory().CreateDbContext());
        }

        [TestMethod]
        public void AddMaterialDefinitionTest()
        {
            var request = new AddMaterialDefinitionRequest()
            {
                MaterialDefinitionId = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };
            var response = new AddMaterialDefinitionAction(request).Execute().Result;

            Assert.IsTrue(response.Succeeded, response.Exception?.Message);
        }
        [TestMethod]
        public void ModifyMaterialDefinitionTest()
        {
            var materialDefinition = UnitOfWork.MaterialDefinitions.GetAll().FirstOrDefault();
            if (materialDefinition != null)
            {
                var request = new ModifyMaterialDefinitionRequest()
                {
                    MaterialDefinitionId = materialDefinition.MaterialDefinitionId,
                    Description = materialDefinition.Description + " (M)"
                };
                var response = new ModifyMaterialDefinitionAction(request).Execute().Result;

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
            }
        }

        [TestMethod]
        public void DeleteMaterialDefinitionTest()
        {
            var materialDefinition = UnitOfWork.MaterialDefinitions.GetAll().FirstOrDefault();
            if (materialDefinition != null)
            {
                var request = new DeleteMaterialDefinitionRequest()
                {
                    MaterialDefinitionId = materialDefinition.MaterialDefinitionId
                };
                var response = new DeleteMaterialDefinitionAction(request).Execute().Result;

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
                var unitOfWork = new UnitOfWork(new DataContextFactory().CreateDbContext());
                Assert.IsNull(unitOfWork.MaterialDefinitions.Get(materialDefinition.MaterialDefinitionId), "Material not deleted");
            }
        }
        [TestMethod]
        public void GetMaterialDefinitionTest()
        {
            var materialDefinition = UnitOfWork.MaterialDefinitions.GetAll().FirstOrDefault();
            if (materialDefinition != null)
            {
                var request = new GetMaterialDefinitionRequest()
                {
                    MaterialDefinitionId = materialDefinition.MaterialDefinitionId
                };
                var response = new GetMaterialDefinitionAction(request).Execute().Result;
                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
            }
        }
        [TestMethod]
        public void GetAllMaterialDefinitionTest()
        {
            var getAllMaterialDefinitionRequest = new GetAllMaterialDefinitionsRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchText = String.Empty
            };
            var getAllMaterialDefinitionResponse = new GetAllMaterialDefinitionsAction(getAllMaterialDefinitionRequest).Execute().Result;
            Assert.IsTrue(getAllMaterialDefinitionResponse.Succeeded, getAllMaterialDefinitionResponse.Exception?.Message);
        }
    }
}