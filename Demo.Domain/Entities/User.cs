using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [Column("userId", TypeName = "int")]
        public required int UserId { get; set; }

        [Column("name", TypeName = "nvarchar")]
        public string? Name { get; set; } = string.Empty;

        [Column("email", TypeName = "varchar")]
        public string? Email { get; set; } = string.Empty;

        [Column("createdAt", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Column("deleted", TypeName = "bit")]
        public bool? IsDeleted { get; set; } = false;

        [Column("deletedAt", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; } = null;

        [Column("accountId", TypeName = "int")]
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account? Account { get; set; } = null;
    }
}
