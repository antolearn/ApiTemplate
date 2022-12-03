using Api.Core.Repositories;
using Api.Core.TestDtos;
using Api.Interfaces;

namespace Api.Startup
{
    public static class MapEndpoints
    {
        public static WebApplication MapProgramTypeEndpoints(this WebApplication app)
        {
            app.MapGet("api/ProgramTypes", (IUnitOfWork unitOfWork, IProgramTypeApi programTypeApi) => programTypeApi.GetAllAsync());
            app.MapPost("api/ProgramType", (ProgramTypeGetAllDto entity, IUnitOfWork unitOfWork, IProgramTypeApi programTypeApi) => programTypeApi.AddAsync(entity));

            return app;
        }


    }
}
