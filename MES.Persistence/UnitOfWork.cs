using Microsoft.EntityFrameworkCore;
using MES.Model;
using MES.Persistence.Repositories;

namespace MES.Persistence
{
	public partial class UnitOfWork : AtomosHyla.Core.UnitOfWork
	{
		public UnitOfWork(DbContext context) : base(context)
		{
			Equipments = new EquipmentRepository(this);
			MaterialDefinitions = new MaterialDefinitionRepository(this);
            WorkOrders = new WorkOrderRepository(this);
        }
        public EquipmentRepository Equipments { get; }
		public MaterialDefinitionRepository MaterialDefinitions { get; }
        public WorkOrderRepository WorkOrders { get; }
	}
}
