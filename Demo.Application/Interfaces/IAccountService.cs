using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// This function is used to change the function of an account, 
        /// used when the (Admin) has authorized wants to change the function according to the available functions in the system.
        /// </summary>
        /// <param name="changeRoleRequest">An object include: Account Id and Role Id</param>
        /// <returns>A response indicating the success or failure of the role change operation. Its include status, message</returns>
        Task<ActionResult> ChangeRoleAsync(ChangeRoleRequest changeRoleRequest);

        /// <summary>
        /// This function is used to reset the password of an account, 
        /// used when the (Admin) has authorized wants to reset the account password,
        /// the password will be changed to the current account's email
        /// </summary>
        /// <param name="resetPasswordRequest">An object include: AccountId</param>
        /// <returns>A response indicating the success or failure of the reset password operation. Its include status, message</returns>
        Task<ActionResult> ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);
    }
}
