using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Account;
using Demo.Application.DTOs.Auth;
using Demo.Application.Interfaces;
using Demo.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Validators
{
    public class AccountValidator: ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountRepository _accountrepository;
        public AccountValidator(IAccountService accountService, IAccountRepository accountRepository) 
        {
            _accountService = accountService;
            _accountrepository = accountRepository;
        }

        /// <summary>
        /// Validate the input value (ChangeRoleRequest) while user uses the change role function
        /// </summary>
        /// <param name="changeRoleRequest">An object include: AccountId, RoleId</param>
        /// <returns>
        /// A response indicating the success or failure of the change role operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return ChangeRoleAsync in IAccountService
        /// </returns>
        public async Task<ActionResult> ChangeRole(ChangeRoleRequest changeRoleRequest)
        {
            try
            {
                var validator = new ChangeRoleRequestValidator();
                ValidationResult result = validator.Validate(changeRoleRequest);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new Exception(error + "");
                }
                
                var account = await _accountrepository.GetAccountByIdAsync(changeRoleRequest.AccountId);

                return account == null ? throw new Exception("Account Not Found !") : await _accountService.ChangeRoleAsync(changeRoleRequest);
            } catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        /// <summary>
        /// Validate the input value (ResetPasswordRequest) while user uses the reset password function
        /// </summary>
        /// <param name="resetPasswordRequest">An object include: AccountId</param>
        /// <returns>
        /// A response indicating the success or failure of the reset password operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return ResetPasswordAsync in IAccountService
        /// </returns>
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            try
            {
                var validator = new ResetPasswordRequestValidator();
                ValidationResult result = validator.Validate(resetPasswordRequest);
                Console.WriteLine(resetPasswordRequest.AccountId);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new Exception(error + "");
                }

                return await _accountService.ResetPasswordAsync(resetPasswordRequest);
            } catch(Exception ex)
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
