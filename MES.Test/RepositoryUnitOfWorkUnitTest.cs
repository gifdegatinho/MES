using AtomosHyla.Core.Library;
using MES.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MES.Model;

namespace MES.Test
{
    [TestClass]
    public class RepositoryUnitOfWorkUnitTest
    {
        public IServiceProvider ServiceProvider { get; }
        public UnitOfWork UnitOfWork { get; }

        public RepositoryUnitOfWorkUnitTest()
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
            UnitOfWork.Materials.Add(new Material()
            {
                MaterialId = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Color = Guid.NewGuid().ToString(),
            });
            UnitOfWork.Save();
            var afterCount = UnitOfWork.Materials.GetAll().Count();

            Assert.IsTrue(afterCount == beforeCount + 1, "Row was not inserted");
        }
    }
}