using AtomosHyla.Core;
using MES.Model;

namespace MES.Persistence.Repositories
{
    public class MaterialRepository : Repository<Material>
    {
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
