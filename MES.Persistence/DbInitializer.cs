using Microsoft.EntityFrameworkCore;

namespace MES.Persistence
{
    public class DbInitializer
    {
        private DbContext DbContext
        {
            get
            {
                return (DbContext)DataContext;
            }
        }
        private UnitOfWork UnitOfWork { get; set; }
        private DataContext DataContext { get; set; }

        public void Initialize()
        {
            DataContext = new DataContextFactory().CreateDbContext();
            DataContext.Database.EnsureCreated();
            UnitOfWork = new UnitOfWork(DataContext);
        }
    }
}
