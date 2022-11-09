using AtomosHyla.Core.Library;
using MES.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.BusinessLogic.Library.Requests;
using MES.BusinessLogic.Actions;
using Microsoft.EntityFrameworkCore;

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
                PageSize = 5,
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

        [TestMethod]
        public void GetMaterialTest()
        {
            var material = UnitOfWork.Materials.GetAll().FirstOrDefault();

            if (material == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var request = new GetMaterialRequest()
                {
                    MaterialId = material.MaterialId
                };
                var action = new GetMaterialAction(request);
                var response = action.Execute().Result;

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
                Assert.AreEqual(material.MaterialId, response.Material.MaterialId);

                if (response.Succeeded == true)
                {
                    Console.WriteLine($"Material id: {material.MaterialId}, Description: {material.Description}, Color: {material.Color}");
                }
            }
        }

        [TestMethod]
        public void AddEquipmentTest()
        {
            var beforeCount = UnitOfWork.Equipments.GetAll().Count();
            var parentEquipment = UnitOfWork.Equipments.GetAll().FirstOrDefault();
            var request = new AddEquipmentRequest()
            {
                EquipmentId = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                ParentEquipmentId = parentEquipment?.EquipmentId
            };
            var action = new AddEquipmentAction(request);
            var response = action.Execute().Result;

            var afterCount = UnitOfWork.Equipments.GetAll().Count();
            Assert.IsTrue(afterCount == beforeCount + 1, "Row was not inserted");

            Assert.IsTrue(response.Succeeded, response.Exception?.Message);
        }

        [TestMethod]
        public void ModifyEquipmentTest()
        {
            var equipment = UnitOfWork.Equipments.GetAll().FirstOrDefault();
            var parentEquipment = UnitOfWork.Equipments.GetAll().FirstOrDefault();

            if (equipment == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var request = new ModifyEquipmentRequest()
                {
                    EquipmentId = equipment.EquipmentId,
                    Description = Guid.NewGuid().ToString(),
                    ParentEquipmentId = parentEquipment?.EquipmentId
                };

                var action = new ModifyEquipmentAction(request);
                var response = action.Execute().Result;

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
            }
        }

        [TestMethod]
        public void DeleteEquipmentTest()
        {
            var equipment = UnitOfWork.Equipments.GetAll()
                .Include(e => e.ChildrenEquipment)
                .Where(e => !e.ChildrenEquipment.Any())
                .FirstOrDefault();

            if (equipment == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var beforeCount = UnitOfWork.Equipments.GetAll().Count();
                var request = new DeleteEquipmentRequest()
                {
                    EquipmentId = equipment.EquipmentId,
                };
                var action = new DeleteEquipmentAction(request);
                var response = action.Execute().Result;

                var afterCount = UnitOfWork.Equipments.GetAll().Count();
                Assert.IsTrue(afterCount == beforeCount - 1, "Row was not deleted");

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);
            }
        }

        [TestMethod]
        public void GetAllEquipmentsTest()
        {
            var request = new GetAllEquipmentsRequest()
            {
                PageSize = 5,
                Page = 0,
            };
            var action = new GetAllEquipmentsAction(request);
            var response = action.Execute().Result;

            foreach (var equipment in response.Equipments)
            {
                Console.WriteLine($"Equipment id: {equipment.EquipmentId}, Description: {equipment.Description}");
            }

            Assert.IsTrue(response.Succeeded, response.Exception?.Message);
        }

        [TestMethod]
        public void GetEquipmentTest()
        {
            var equipment = UnitOfWork.Equipments.GetAll().FirstOrDefault();

            if (equipment == null)
            {
                Assert.Inconclusive();
            }
            else
            {
                var request = new GetEquipmentRequest()
                {
                    EquipmentId = equipment.EquipmentId
                };
                var action = new GetEquipmentAction(request);
                var response = action.Execute().Result;

                Assert.IsTrue(response.Succeeded, response.Exception?.Message);

                if (response.Succeeded == true)
                {
                    Console.WriteLine($"Equipment id: {equipment.EquipmentId}, Description: {equipment.Description}");
                }
            }
        }
    }
}