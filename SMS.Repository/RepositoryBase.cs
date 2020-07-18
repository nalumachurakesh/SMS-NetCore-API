using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression, bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression, int skip, int take, bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet.Where(expression).Skip(skip).Take(take);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public IEnumerable<T> Find(Func<T, bool> match)
        {
            return _dbSet.Where(match);
        }

        public IList<T> FindAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IList<T>> FindAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public T FindByID(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindByIDAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }

        public void AddRange(IList<T> Ts)
        {
            _dbSet.AddRange(Ts);
        }

        public async Task BulkInsertAsync(IList<T> entities)
        {
            await _dbContext.BulkInsertAsync(entities);
        }

        public async Task BulkUpdateAsync(IList<T> entities)
        {
            await _dbContext.BulkUpdateAsync(entities);
        }
    }
}
