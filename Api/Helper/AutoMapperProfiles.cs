using AutoMapper;
using Api.Core.Entities;
using Api.Core.TestDtos;

namespace Onion.Api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProgramType, ProgramTypeGetAllDto>().ReverseMap();            

        }
    }
}
