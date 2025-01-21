using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Auth;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Validators
{
    public class AuthValidator: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthValidator(IAuthService authService) 
        {
            _authService = authService;
        }

        /// <summary>
        /// Validate the input value (LoginRequest) while user uses the login function
        /// </summary>
        /// <param name="loginRequest">An object include: Email, Password</param>
        /// <returns>
        /// A response indicating the success or failure of the login operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return LoginAsync in IAuthService
        /// </returns>
        public async Task<ActionResult> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var validator = new LoginRequestValidator();
                ValidationResult result = validator.Validate(loginRequest);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new Exception(error + "");
                }
                return await _authService.LoginAsync(loginRequest);

            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }
    }
}
