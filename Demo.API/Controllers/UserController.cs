using Demo.Application.DTOs.Role;
using Demo.Application.DTOs.Site;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using Demo.Application.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserValidator _userValidator;
        public UserController(IUserService userService, UserValidator userValidator) 
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<IEnumerable<GetUserResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult<IEnumerable<GetUserResponse>>> GetAllUser()
        {
            return await _userService.GetListUserAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GetUserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult<GetUserResponse>> GetUserById(int id)
        {
            return await _userValidator.GetUserAsyncValidator(id);
        }

        // GET api/<UserController>/get-user-by-email/string@fpt.com
        [HttpGet("get-user-by-email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GetUserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult<GetUserResponse>> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmailAsync(email);
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GetUserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        [Authorize]
        public async Task<ActionResult<GetUserResponse>> AddUser(AddUserRequest user)
        {
            return await _userValidator.AddUserAsyncValidator(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomResponse<GetUserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        [Authorize]
        public async Task<ActionResult<GetUserResponse>> UpdateUser(int id, UpdateUserRequest user)
        {
            return await _userValidator.UpdateUserAsyncValidator(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            return await _userService.DeleteUserAsync(id);
        }
    }
}
