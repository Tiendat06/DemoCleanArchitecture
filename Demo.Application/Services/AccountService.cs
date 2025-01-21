using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Account;
using Demo.Application.Interfaces;
using Demo.Application.Mapper.AccountMapper;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Demo.Application.Services
{
    public class AccountService : ControllerBase, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public AccountService(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public async Task<ActionResult> ChangeRoleAsync(ChangeRoleRequest changeRoleRequest)
        {
            try
            {
                var account = AccountMapperRequest.ChangeRoleMapDTOToEntity(changeRoleRequest);
                var accountAfterChanged = await _accountRepository.UpdateAccountRoleAsync(account) ?? throw new Exception("Change Role Failed !");

                return Ok(new
                {
                    status = 200,
                    message = "Change Role Successfully !",
                });
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest)
        {
            try
            {
                var account = await _accountRepository.GetAccountByIdAsync(resetPasswordRequest.AccountId) ?? throw new Exception("Account not found !");
                
                var user = await _userRepository.GetUserByAccountIdAsync(resetPasswordRequest.AccountId) ?? throw new Exception("User not found !");
                var userEmail = user?.Email;

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userEmail);
                account.Password = hashedPassword;

                var isResetPassword = await _accountRepository.UpdateAccountPasswordToEmailAsync(account) == false ? throw new Exception("Password unchanged !"): true;

                return Ok(new
                {
                    status = 200,
                    message = "Reset Password Successfully !"
                });
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
