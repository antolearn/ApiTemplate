
using Api.Core.Entities;
using Api.Core.Repositories;
using Api.Infrastructure.Data;

namespace Api.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IGenericRepository<ProgramType> ProgramTypes => new GenericService<ProgramType>(appDbContext);
        public void Dispose()
        {
            appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}
