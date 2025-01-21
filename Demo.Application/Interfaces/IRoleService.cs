using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Role;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Application.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// This function is used to get all roles in the system,
        /// used when user wants to list all roles
        /// </summary>
        /// <returns>A response indicating the success or failure of the get all role operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (IEnumerable<GetRoleResponse>)
        /// </returns>
        Task<ActionResult<IEnumerable<GetRoleResponse>>> GetAllRolesAsync();

        /// <summary>
        /// This function is used to get role by role id in the system,
        /// used when user wants to get a specific role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A response indicating the success or failure of the get role by id operation. 
        /// Its include status, message,
        /// if success, it will include more - data attribute (GetRoleResponse)
        /// </returns>
        Task<ActionResult<GetRoleResponse>> GetRoleByIdAsync(int id);
        
    }
}
