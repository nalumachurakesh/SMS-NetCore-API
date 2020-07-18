using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public interface IRepositoryBase<T>
    {
        void Add(T newEntity);
        void Delete(T entity);
        void Update(T entity);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression, bool enableTracking = false);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression, int skip, int take, bool enableTracking = false);
        IEnumerable<T> Find(Func<T, bool> match);
        IList<T> FindAll();
        Task<IList<T>> FindAllAsync();
        T FindByID(int id);
        Task<T> FindByIDAsync(int id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool enableTracking = false);
        void AddRange(IList<T> range);
        Task BulkInsertAsync(IList<T> entities);
        Task BulkUpdateAsync(IList<T> entities);
    }
}
