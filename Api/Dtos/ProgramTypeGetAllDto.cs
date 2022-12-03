using System.ComponentModel.DataAnnotations;

namespace Api.Core.TestDtos
{
    public class ProgramTypeGetAllDto
    {
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
