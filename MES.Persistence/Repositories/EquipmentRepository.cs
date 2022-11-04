using AtomosHyla.Core;
using MES.Model;

namespace MES.Persistence.Repositories
{
    public class EquipmentRepository : Repository<Equipment>
    {
        public EquipmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
