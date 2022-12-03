using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Core.Entities
{
    [Index((nameof(Name)), IsUnique = true)]
    public class ProgramType 
    {
        // Base
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        [Column(Order = 2)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(256)]
        [Column(Order = 3)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(Order = 92)]
        public int OrgId { get; set; }
        [Column(Order = 93)]
        public int? PropertyId { get; set; }

        // WorkFlow
        [Column(Order = 94)]
        public bool IsActive { get; set; } = true;
        [Column(Order = 95)]
        public bool IsApproved { get; set; } = true;
        /** Audit **/

        [MaxLength(128), Required]
        [Column(Order = 96)]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        [Column(Order = 97)]
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        [MaxLength(128), Required]
        [Column(Order = 98)]
        public string ModifiedBy { get; set; } = string.Empty;
        [Required]
        [Column(Order = 99)]
        public DateTime ModifiedDateTime { get; set; }


    }
}
