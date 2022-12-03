using Api.Core.Interfaces;
using Api.Core.Repositories;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Api.Infrastructure.Services
{
    public class GenericService<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext appDbContext;
        private readonly DbSet<T> dbSet;

        public GenericService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            dbSet = appDbContext.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddRangeAsync(entity);

        }



        public async Task AddRange(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy = null, List<string>? includes = null)
        {
            IQueryable<T> query = dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = (IQueryable<T>)orderBy(query);
            }
            return await query.FirstOrDefaultAsync(expression);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = (IQueryable<T>)orderBy(query);
            }
            return await query.ToListAsync();
        }

        public async Task<bool> HardDelete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null) return false;
            dbSet.Remove(entity);
            return true;
        }

        public async Task<bool> HardDeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            appDbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }


    }
}
