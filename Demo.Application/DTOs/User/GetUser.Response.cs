using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.DTOs.User
{
    public class GetUserResponse
    {
        public int? UserId { get; set; } = -1;
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        //public string? Password { get; set; } = null;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
        public int? AccountId { get; set; } = -1;
        public string? RoleName { get; set; } = string.Empty;
    }
}
