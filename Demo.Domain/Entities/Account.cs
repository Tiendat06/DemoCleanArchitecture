using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [Required]
        [Column("accountId", TypeName = "int")]
        public required int AccountId { get; set; }

        [Column("username", TypeName = "nvarchar")]
        public string? UserName { get; set; } = string.Empty;

        [Column("password", TypeName = "varchar")]
        public string? Password { get; set; } = null;

        [Column("createdAt", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("updatedAt", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Column("deleted", TypeName = "bit")]
        public bool? IsDeleted { get; set; } = false;

        [Column("deletedAt", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; } = null;

        [Column("role_id", TypeName = "int")]
        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role? Role { get; set; } = null;

        [NotMapped]
        public User? User { get; set; } = null;
    }
}
