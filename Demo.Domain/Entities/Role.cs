using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [Required]
        [Column("role_id", TypeName = "int")]
        public required int RoleId { get; set; }

        [Column("role_name", TypeName = "varchar")]
        public string? RoleName { get; set; } = string.Empty;

        [NotMapped]
        public Account? Account { get; set; } = null;
    }
}
