using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;


namespace Demo.Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// This function is used to get user by user id in the system,
        /// used when user wants to get a specific user by user id
        /// </summary>
        /// <param name="id">A param data, which is an user id</param>
        /// <returns>
        /// A response indicating the success or failure of the get user by id operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (GetUserResponse)
        /// </returns>
        Task<ActionResult<GetUserResponse>> GetUserAsync(int id);

        /// <summary>
        /// This function is used to get user by user email in the system,
        /// used when user wants to get a specific user by email
        /// </summary>
        /// <param name="email">A param data, which is an user id</param>
        /// <returns>
        /// A response indicating the success or failure of the get user by email operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (GetUserResponse)
        /// </returns>
        Task<ActionResult<GetUserResponse>> GetUserByEmailAsync(string email);

        /// <summary>
        /// This function is used to udpate user informations,
        /// used when (Admin) wants to edit user informations
        /// </summary>
        /// <param name="id">A param data, which is user id</param>
        /// <param name="user">An object include: Name, Email, UserName</param>
        /// <returns>
        /// A response indicating the success or failure of the update user information operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (GetUserResponse)
        /// </returns>
        Task<ActionResult<GetUserResponse>> UpdateUserAsync(int id, UpdateUserRequest user);

        /// <summary>
        /// This function is used to get all user,
        /// used when user wants to list all users in the system
        /// </summary>
        /// <returns>
        /// A response indicating the success or failure of the get all users operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (IEnumerable<GetUserResponse>)
        /// </returns>
        Task<ActionResult<IEnumerable<GetUserResponse>>> GetListUserAsync();

        /// <summary>
        /// This function is used to delete user by user id,
        /// used when (Admin) wants to delete specific user in the system
        /// </summary>
        /// <param name="id">A param data, which is user id</param>
        /// <returns>
        /// A response indicating the success or failure of the delete user by user id operation. 
        /// Its include status, message
        /// </returns>
        Task<ActionResult<bool>> DeleteUserAsync(int id);

        /// <summary>
        /// This function is used to add new user,
        /// used when (Admin) wants to add specific user in the system
        /// </summary>
        /// <param name="user">An object include: Name, Email, UserName, Password</param>
        /// <returns>
        /// A response indicating the success or failure of the delete user by user id operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (GetUserResponse)
        /// </returns>
        Task<ActionResult<GetUserResponse>> AddUserAsync(AddUserRequest user);
    }
}
