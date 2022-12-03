using System.Linq.Expressions;
namespace Api.Core.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
            List<string> includes = null
            );
        Task<bool> HardDelete(int id);
        Task<bool> HardDeleteRange(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task<bool> UpdateAsync(T entity);

    }
}
