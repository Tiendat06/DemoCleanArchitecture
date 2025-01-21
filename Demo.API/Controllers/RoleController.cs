using Demo.Application.DTOs.Role;
using Demo.Application.DTOs.Site;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<IEnumerable<GetRoleResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult<IEnumerable<GetRoleResponse>>> GetAllRoles()
        {
            return await _roleService.GetAllRolesAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GetRoleResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult<GetRoleResponse>> GetRoleById(int id)
        {
            return await _roleService.GetRoleByIdAsync(id);
        }

        
    }
}
