using Api.Core.Entities;
using Api.Core.Repositories;
using Api.Core.TestDtos;
using Api.Interfaces;
using AutoMapper;
using System.Reflection;
using FluentValidation;

namespace Api.Api
{
    public class ProgramTypeApi : GenericApi<ProgramTypeGetAllDto>, IProgramTypeApi
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private ILogger<ProgramTypeApi> logger;
        private ProgramType newProgramType;
        public ProgramTypeApi
            (
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            ILogger<ProgramTypeApi> logger
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
    }
}
