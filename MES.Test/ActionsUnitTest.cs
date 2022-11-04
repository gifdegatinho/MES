using AtomosHyla.Core.Library;
using MES.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}