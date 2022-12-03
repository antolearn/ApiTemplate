

using Api.Core.Entities;

namespace Api.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ProgramType> ProgramTypes{ get; }
    }
}
