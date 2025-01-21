using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Validators
{
    public class UserValidator: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public UserValidator(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Validate the input value (id) while user uses the get user by id function
        /// </summary>
        /// <param name="id">A param data, which is user id</param>
        /// <returns>
        /// A response indicating the success or failure of the get user by id operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return GetUserAsync in IUserService
        /// </returns>
        public async Task<ActionResult<GetUserResponse>> GetUserAsyncValidator(int? id)
        {
            try
            {
                if (id != 0 || id.HasValue)
                {
                    return await _userService.GetUserAsync(id.Value);
                }
                throw new Exception("Invalid Id !");
            } catch (Exception ex) 
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// Validate the input value (AddUserRequest) while user uses the add new user function
        /// </summary>
        /// <param name="addUserRequest">An object include: Name, Email, UserName, Password</param>
        /// <returns>
        /// A response indicating the success or failure of the add new user operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return AddUserAsync in IUserService
        /// </returns>
        public async Task<ActionResult<GetUserResponse>> AddUserAsyncValidator(AddUserRequest addUserRequest)
        {
            try
            {
                var validator = new AddUserRequestValidator();
                ValidationResult result = validator.Validate(addUserRequest);
                if (!result.IsValid) 
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new Exception(error+"");
                }
                var user = await _userRepository.GetUserByEmailAsync(addUserRequest.Email);

                return user != null ? throw new Exception("Email is exists !") : await _userService.AddUserAsync(addUserRequest);
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// Validate the input value (id, UpdateUserRequest) while user uses the update user function
        /// </summary>
        /// <param name="id">A param data, which is user id</param>
        /// <param name="updateUserRequest">An object include: Name, Email, UserName</param>
        /// <returns>
        /// A response indicating the success or failure of the update user operation.
        /// If error -> throw new Exception with the error message.
        /// If success -> return UpdateUserAsync in IUserService
        /// </returns>
        public async Task<ActionResult<GetUserResponse>> UpdateUserAsyncValidator(int id, UpdateUserRequest updateUserRequest)
        {
            try
            {
                var validator = new UpdateUserRequestValidator();
                ValidationResult result = validator.Validate(updateUserRequest);
                if(!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new Exception(error + "");
                }
                var user = await _userRepository.GetUserByEmailAndExceptUserIdAsync(updateUserRequest.Email, id);

                return user != null ? throw new Exception("Email is exists !") : await _userService.UpdateUserAsync(id, updateUserRequest);
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
