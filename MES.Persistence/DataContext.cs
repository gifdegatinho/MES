using AtomosHyla.Core;
using Microsoft.EntityFrameworkCore;
using MES.Model;

namespace MES.Persistence
{
    public class DataContext : DbContext
    {
        public readonly DatabaseType DatabaseType;

        /// <summary>
        /// The constructor is accessible only via DataContextFactory
        /// </summary>
        /// <param name="options"></param>
        internal DataContext(DatabaseType databaseType, DbContextOptions<DataContext> options) : base(options)
        {
            DatabaseType = databaseType;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new LoggerProvider());
            //optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.ParentEquipment)
                .WithMany(e => e.ChildrenEquipment)
                .HasForeignKey(e => e.ParentEquipmentId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Equipment> Equipments { get; set; }
    }
}
