using System.Threading.Tasks;

namespace AtomosHyla.Core
{
    public interface IUnitOfWork
    {
        object Context { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
