using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.DTOs.Role
{
    public class GetRoleResponse
    {
        public int? RoleId { get; set; } = -1;
        public string? RoleName { get; set; } = string.Empty;
    }
}
