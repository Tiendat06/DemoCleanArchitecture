using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Role;
using Demo.Application.Interfaces;
using Demo.Application.Mapper.RoleMapper;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Services
{
    public class RoleService: ControllerBase, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) 
        {
            _roleRepository = roleRepository;
        }

        public async Task<ActionResult<IEnumerable<GetRoleResponse>>> GetAllRolesAsync()
        {
            try
            {
                var roleList = await _roleRepository.getAllRoles();
                var roleListMapperDTO = RoleMapperResponse.GetRoleListMapEntityToDTO(roleList);
                return Ok(new
                {
                    status = 200,
                    data = roleListMapperDTO,
                    message = "Load Roles Successfully !"
                });

            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        public async Task<ActionResult<GetRoleResponse>> GetRoleByIdAsync(int id)
        {
            try
            {
                var role = await _roleRepository.getRoleById(id) ?? throw new Exception("Role not found !");
                var roleMapperDTO = RoleMapperResponse.GetRoleMapEntityToDTO(role);

                return Ok(new
                {
                    status = 200,
                    data = roleMapperDTO,
                    message = "Load Role Successfully !",
                });
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }
    }
}
