using Microsoft.EntityFrameworkCore;
using MES.Persistence.Repositories;

namespace MES.Persistence
{
	public partial class UnitOfWork : AtomosHyla.Core.UnitOfWork
	{
		public UnitOfWork(DbContext context) : base(context)
		{
			Equipments = new EquipmentRepository(this);
        }
        public EquipmentRepository Equipments { get; }
	}
}
