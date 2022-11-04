using AtomosHyla.Core;
using MES.Model;

namespace MES.Persistence.Repositories
{
    public class WorkOrderRepository : Repository<WorkOrder>
    {
        public WorkOrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
