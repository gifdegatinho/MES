using AtomosHyla.Core;
using MES.Model;
using System;

namespace MES.Persistence.Repositories
{
    public class MaterialRepository : Repository<Material>
    {
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public object Delete(string materialId)
        {
            throw new NotImplementedException();
        }
    }
}
