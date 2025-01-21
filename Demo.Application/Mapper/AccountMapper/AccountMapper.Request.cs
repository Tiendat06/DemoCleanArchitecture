using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Account;
using Demo.Application.DTOs.User;
using Demo.Domain.Entities;

namespace Demo.Application.Mapper.AccountMapper
{
    public class AccountMapperRequest
    {
        /// <summary>
        /// Convert AccountUserRequest object to Account object
        /// </summary>
        /// <param name="addUserRequest">An object include: Name, Email, UserName, Password</param>
        /// <returns>
        /// Account Object
        /// </returns>
        public static Account AddUserMapDTOToEntityAccount(AddUserRequest addUserRequest)
        {
            return new Account
            {
                AccountId = 0,
                UserName = addUserRequest.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(addUserRequest.Password, BCrypt.Net.BCrypt.GenerateSalt(10)),
            };
        }

        /// <summary>
        /// Convert UpdateUserRequest object to Account object
        /// </summary>
        /// <param name="accountId">A param data: Account ID</param>
        /// <param name="updateUserRequest">An object include: Name, Email, UserName</param>
        /// <returns>
        /// Account Object
        /// </returns>
        public static Account UpdateUserMapDTOToEntity(int accountId, UpdateUserRequest updateUserRequest)
        {
            return new Account
            {
                AccountId = accountId,
                UserName = updateUserRequest.UserName,
                UpdatedAt = DateTime.Now,
            };
        }

        /// <summary>
        /// Convert ChangeRoleRequest object to Account object
        /// </summary>
        /// <param name="changeRoleRequest">An object include: AccountId, RoleId</param>
        /// <returns>
        /// Account Object
        /// </returns>
        public static Account ChangeRoleMapDTOToEntity(ChangeRoleRequest changeRoleRequest)
        {
            return new Account
            {
                AccountId = changeRoleRequest.AccountId,
                RoleId = changeRoleRequest.RoleId
            };
        }
    }
}
