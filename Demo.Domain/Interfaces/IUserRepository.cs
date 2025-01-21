using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// This function is used to query to database, insert new user to User table
        /// </summary>
        /// <param name="user">An entity: User</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> AddUserAsync(User user);

        /// <summary>
        /// This function is used to query to database, update specific user to User table
        /// </summary>
        /// <param name="user">An Entity: User</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> UpdateUserAsync(User user);

        /// <summary>
        /// This function is used to query to database, soft delete specific user from User table
        /// </summary>
        /// <param name="user">An Entity: User</param>
        /// <returns>
        /// Boolean Value
        /// </returns>
        Task<bool> SoftDeleteUserAsync(User user);

        /// <summary>
        /// This function is used to query to database, hard delete specific user by id from User table
        /// </summary>
        /// <param name="id">A param data: user id</param>
        /// <returns>
        /// Boolean Value
        /// </returns>
        Task<bool> HardDeleteUserAsync(int id);

        /// <summary>
        /// This function is used to query to database, get specific user by user id from User table
        /// </summary>
        /// <param name="id">A param data: user id</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> GetUserByIdAsync(int id);

        /// <summary>
        /// This function is used to query to database, get all users from User table
        /// </summary>
        /// <returns>
        /// List of User
        /// </returns>
        Task<List<User>> GetListUserAsync();

        /// <summary>
        /// This function is used to query to database, get specific user by user's email from User table
        /// </summary>
        /// <param name="email">A param data: User's email</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// <summary>
        /// This function is used to query to database, get specific user by user's email and
        /// the query does not count user whose user id is passed in
        /// </summary>
        /// <param name="email">A param data: user email</param>
        /// <param name="userId">A param data: user id</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> GetUserByEmailAndExceptUserIdAsync(string email, int userId);

        /// <summary>
        /// This function is used to query to database, get specific user by account id from User table
        /// </summary>
        /// <param name="accountId">A param data: Account Id</param>
        /// <returns>
        /// User Object
        /// </returns>
        Task<User?> GetUserByAccountIdAsync(int accountId);
    }
}
