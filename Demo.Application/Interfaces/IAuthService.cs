using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// This function is used to login to the system, 
        /// used when user wants to login to the system,
        /// while login, the system will save the jwt in cookie (this token cannot be accessed by JS) to support authorization
        /// </summary>
        /// <param name="loginRequest">An object include: Email, Password</param>
        /// <returns>A response indicating the success or failure of the login operation. Its include status, message</returns>
        Task<ActionResult> LoginAsync(LoginRequest loginRequest);

        /// <summary>
        /// This function is used to logout the system, 
        /// used when user wants to logout,
        /// while logout, the system will delete the jwt in cookie
        /// </summary>
        /// <returns>A response indicating the success or failure of the logout operation. Its include status, message</returns>
        Task<ActionResult> LogoutAsync();
    }
}
