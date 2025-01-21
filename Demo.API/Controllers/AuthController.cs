using Demo.Application.DTOs.Auth;
using Demo.Application.DTOs.Site;
using Demo.Application.Interfaces;
using Demo.Application.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AuthValidator _authValidator;
        public AuthController(IAuthService authService, AuthValidator authValidator) 
        {
            _authService = authService;
            _authValidator = authValidator;
        }

        // POST api/<AuthController>/login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult> LoginPost(LoginRequest loginRequest)
        {
            return await _authValidator.LoginAsync(loginRequest);
        }

        // GET api/<AuthController>/logout
        [HttpGet("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        public async Task<ActionResult> Logout()
        {
            return await _authService.LogoutAsync();
        }
    }
}
