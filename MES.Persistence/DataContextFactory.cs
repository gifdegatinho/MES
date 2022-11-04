using AtomosHyla.Core;
using AtomosHyla.Core.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MES.Persistence
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args = null)
        {
            IConfiguration configuration = ServiceProviderFactory.ServiceProvider.GetService<IConfiguration>();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            var contextSection = configuration.GetSection("ConnectionStrings")?.GetSection("Context");
            if (contextSection == null)
            {
                throw new ArgumentException("Context section in ConnectionStrings not found");
            }

            string connectionString = contextSection.GetSection("connectionString")?.Value;
            if (connectionString == null)
            {
                throw new ArgumentException("connectionString in Context not found");
            }

            string providerName = contextSection.GetSection("providerName")?.Value;
            if (providerName == null)
            {
                throw new ArgumentException("connectionString in Context not found");
            }

            DatabaseType databaseType;
            if (providerName == "System.Data.SqlClient")
            {
                databaseType = DatabaseType.SqlServer;
                optionsBuilder.UseSqlServer(
                    connectionString,
                    builder => builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(3), null));
            }
            else
            {
                throw new ArgumentException($"providerName '{providerName}' not supported");
            }

            DataContext dataContext = new DataContext(databaseType, optionsBuilder.Options);
            dataContext.Database.SetCommandTimeout(30);

            return dataContext;
        }
    }
}