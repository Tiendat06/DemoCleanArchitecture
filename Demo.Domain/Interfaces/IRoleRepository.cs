using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// This function is used to query to database, get all roles from Role table
        /// </summary>
        /// <returns>
        /// List of Roles
        /// </returns>
        Task<List<Role>> getAllRoles();

        /// <summary>
        /// This function is used to query to database, get specific role by role id from Role table
        /// </summary>
        /// <param name="id">A param data: role id</param>
        /// <returns>
        /// Role Object
        /// </returns>
        Task<Role?> getRoleById(int id);
    }
}
