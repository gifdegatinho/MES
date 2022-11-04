using AtomosHyla.Core;
using MES.Model;

namespace MES.Persistence.Repositories
{
    public class MaterialDefinitionRepository : Repository<MaterialDefinition>
    {
        public MaterialDefinitionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
