using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using Demo.Application.Mapper.UserMapper;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Demo.Application.Mapper.AccountMapper;

namespace Demo.Application.Services
{
    public class UserService: ControllerBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public async Task<ActionResult<GetUserResponse>> AddUserAsync(AddUserRequest addUserRequest)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(addUserRequest.Password, BCrypt.Net.BCrypt.GenerateSalt(10));
                var account = new Account
                {
                    AccountId = 0,
                    UserName = addUserRequest.UserName,
                    Password = hashedPassword,
                    RoleId = 2,
                };
                var addedAccount = await _accountRepository.AddAccountAsync(account) ?? throw new Exception("Add Failed !");
                var accountId = addedAccount.AccountId;

                var user = new User
                {
                    UserId = 0,
                    Name = addUserRequest.UserName,
                    Email = addUserRequest.Email,
                    AccountId = accountId,
                };
                var addedUser = await _userRepository.AddUserAsync(user);
                if (addedUser == null) 
                { 
                    await _accountRepository.HardDeleteAccountAsync(accountId);
                    throw new Exception("Add Failed !");
                }
                var userMapperDTO = UserMapperResponse.GetUserMapEntityToDTO(addedUser);

                return Ok(new
                {
                    status = 201,
                    data = userMapperDTO,
                    message = "Add User Successfully !",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult<bool>> DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception("Account not found !");
                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;

                var accountId = user?.AccountId ?? throw new Exception("Account not found !");
                var account = await _accountRepository.GetAccountByIdAsync(accountId) ?? throw new Exception("Account not found !");
                account.IsDeleted = true;
                account.DeletedAt = DateTime.Now;

                var isDeletedUser = await _userRepository.SoftDeleteUserAsync(user);
                var isDeletedAccount = await _accountRepository.SoftDeleteAccountAsync(account);

                return Ok(new
                {
                    status = 200,
                    message = "Delete Successfully !",
                });
            } catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult<IEnumerable<GetUserResponse>>> GetListUserAsync()
        {
            try
            {
                var userList = await _userRepository.GetListUserAsync() ?? throw new Exception("No userss Is Founded");
                var userListMapperDTO = UserMapperResponse.GetUserListMapEntityToDTO(userList);

                return Ok(new
                {
                    staus = 200,
                    data = userListMapperDTO,
                    message = "Load Users Successfully !"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    staus = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult<GetUserResponse>> GetUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id) ?? throw new Exception("User not found");
                var userMapperDTO = UserMapperResponse.GetUserMapEntityToDTO(user);

                return Ok(new
                {
                    staus = 200,
                    data = userMapperDTO,
                    message = "Load User Successfully !"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }
        
        public async Task<ActionResult<GetUserResponse>> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new Exception("User not found !");
                var userMapperDTO = UserMapperResponse.GetUserMapEntityToDTO(user);

                return Ok(new
                {
                    staus = 200,
                    data = userMapperDTO,
                    message = "Load User Successfully !",
                });

            } catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult<GetUserResponse>> UpdateUserAsync(int userId, UpdateUserRequest updateUserRequest)
        {
            try
            {   
                var userBeforeUpdate = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception("User not found !");

                var accountId = userBeforeUpdate?.AccountId ?? throw new Exception("Account not found !");
                var account = AccountMapperRequest.UpdateUserMapDTOToEntity(accountId, updateUserRequest);
                var updatedAccount = await _accountRepository.UpdateAccountAsync(account);

                var user = UserMapperRequest.UpdateUserMapDTOToEntity(userId, accountId, updateUserRequest);
                var updatedUser = await _userRepository.UpdateUserAsync(user);

                var userAfterUpdate = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception("User not found !");
                var userMapperDTO = UserMapperResponse.GetUserMapEntityToDTO(userAfterUpdate);

                return Ok(new
                {
                    status = 200,
                    data = userMapperDTO,
                    message = "Update User Successfully !",
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
