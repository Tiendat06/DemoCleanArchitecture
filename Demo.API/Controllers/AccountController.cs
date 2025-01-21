using Demo.Application.DTOs.Account;
using Demo.Application.DTOs.Site;
using Demo.Application.Interfaces;
using Demo.Application.Validators;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly AccountValidator _accountValidator;
        public AccountController(IAccountService accountService, AccountValidator accountValidator) 
        {
            _accountService = accountService;
            _accountValidator = accountValidator;
        }

        // POST: api/<AccountController>/change-role
        [HttpPost("change-role")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        [Authorize]
        public async Task<ActionResult> ChangeRole(ChangeRoleRequest changeRoleRequest)
        {
            return await _accountValidator.ChangeRole(changeRoleRequest);
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DefaultResponse))]
        [Authorize]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            return await _accountValidator.ResetPassword(resetPasswordRequest);
        }
        
    }
}
