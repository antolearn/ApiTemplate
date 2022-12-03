namespace Api.Interfaces
{
    public interface IGenericApi<T> where T : class
    {
        Task<IResult> GetAllAsync();
        Task<IResult> AddAsync(T entity);
    }
}
