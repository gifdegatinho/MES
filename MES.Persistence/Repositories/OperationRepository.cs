using AtomosHyla.Core;
using MES.Model;

namespace MES.Persistence.Repositories
{
    public class OperationRepository : Repository<Operation>
    {
        public OperationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
