using Api.Core.Entities;
using Api.Core.Repositories;
using Api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Services
{
    public class ProgramTypeService : GenericService<ProgramType>, IProgramTypeRepository
    {
        public ProgramTypeService(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
