
using Api.Core.TestDtos;

namespace Api.Interfaces
{
    public interface IProgramTypeApi : IGenericApi<ProgramTypeGetAllDto>
    {
        Task<IResult> GetAllAsync();
        Task<IResult> AddAsync(ProgramTypeGetAllDto entity);
    }
}