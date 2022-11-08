using AtomosHyla.Core.Library;
using MES.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.Model;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Actions;

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
        public void AddMaterialTest()
        {
            var beforeCount = UnitOfWork.Materials.GetAll().Count();
            var request = new AddMaterialRequest()
            {
                MaterialId = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Color = Guid.NewGuid().ToString(),
            };

            var action = new AddMaterialAction(request);
            var response = action.Execute().Result;

            var afterCount = UnitOfWork.Materials.GetAll().Count();

            Assert.IsTrue(afterCount == beforeCount + 1, "Row was not inserted");
            Assert.IsTrue(response.Succeeded, "Row was not inserted");
        }

        [TestMethod]
        public void ModifyMaterialTest()
        {
            var material = UnitOfWork.Materials.GetAll().FirstOrDefault();

            if (material == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var request = new ModifyMaterialRequest()
                {
                    MaterialId = material.MaterialId,
                    Description = Guid.NewGuid().ToString(),
                    Color = Guid.NewGuid().ToString(),
                };

                var action = new ModifyMaterialAction(request);
                var response = action.Execute().Result;

                Assert.IsTrue(response.Succeeded, "Row was not modified");
            }
        }

        [TestMethod]
        public void DeleteMaterialTest()
        {
            var material = UnitOfWork.Materials.GetAll().FirstOrDefault();

            if (material == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var beforeCount = UnitOfWork.Materials.GetAll().Count();
                var request = new DeleteMaterialRequest()
                {
                    MaterialId = material.MaterialId
                };
                var action = new DeleteMaterialAction(request);
                var response = action.Execute().Result;

                Assert.IsTrue(response.Succeeded, "Row was not deleted");

                var afterCount = UnitOfWork.Materials.GetAll().Count();

                Assert.IsTrue(afterCount == beforeCount - 1, "Row was not deleted");
            }
        }

        [TestMethod]
        public void GetAllMaterialsTest()
        {
            var request = new GetAllMaterialsRequest()
            {
                PageSize = 3,
                Page = 0,
                SearchString = "Action"
            };
            var action = new GetAllMaterialsAction(request);
            var response = action.Execute().Result;


            foreach (var material in response.Materials)
            {
                Console.WriteLine($"Material id: {material.MaterialId}, Description: {material.Description}, Color: {material.Color}");
            }

            Assert.IsTrue(response.Succeeded, response.Exception?.Message);
        }
    }
}