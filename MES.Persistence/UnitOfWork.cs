using Microsoft.EntityFrameworkCore;
using MES.Persistence.Repositories;
using System.Buffers;

namespace MES.Persistence
{
	public partial class UnitOfWork : AtomosHyla.Core.UnitOfWork
	{
		public UnitOfWork(DbContext context) : base(context)
		{
			Equipments = new EquipmentRepository(this);
			Materials = new MaterialRepository(this);
			WorkOrders = new WorkOrderRepository(this);
			Operations = new WorkOrderRepository(this);
        }
        public EquipmentRepository Equipments { get; }
		public MaterialRepository Materials { get; }
		public WorkOrderRepository WorkOrders { get; }
		public WorkOrderRepository Operations { get; }
	}
}
