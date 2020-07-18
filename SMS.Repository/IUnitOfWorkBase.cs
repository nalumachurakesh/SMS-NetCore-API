using System.Threading.Tasks;

namespace SMS.Repository
{
    public interface IUnitOfWorkBase<TContext>
    {
        TContext Context { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
