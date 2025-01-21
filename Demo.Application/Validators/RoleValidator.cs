using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Role;
using Demo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Validators
{
    public class RoleValidator: ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleValidator(IRoleService roleService) 
        {
            _roleService = roleService;
        }
    }
}
