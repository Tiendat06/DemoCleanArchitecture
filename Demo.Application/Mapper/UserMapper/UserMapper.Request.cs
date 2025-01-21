using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.User;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Demo.Application.Mapper.UserMapper
{
    public class UserMapperRequest
    {
        /// <summary>
        /// Convert AddUserRequest object to User object
        /// </summary>
        /// <param name="addUserRequest">An object include: Name, Email, UserName, Password</param>
        /// <returns>
        /// User Object
        /// </returns>
        public static User AddUserMapDTOToEntityUser(AddUserRequest addUserRequest)
        {
            return new User
            {
                UserId = 0,
                Name = addUserRequest.Name,
                Email = addUserRequest.Email,
            };
        }

        /// <summary>
        /// Convert UpdateUserRequest object to User object
        /// </summary>
        /// <param name="id">A param data, which is user id</param>
        /// <param name="accountId">A param data, which is account id</param>
        /// <param name="updateUserRequest">An object include: Name, Email, UserName</param>
        /// <returns>
        /// User Object
        /// </returns>
        public static User UpdateUserMapDTOToEntity(int id, int accountId, UpdateUserRequest updateUserRequest)
        {
            return new User
            {
                UserId = id,
                Name = updateUserRequest.Name,
                Email = updateUserRequest.Email,
                UpdatedAt = DateTime.Now,
                AccountId = accountId,
            };
        }

    }
}
