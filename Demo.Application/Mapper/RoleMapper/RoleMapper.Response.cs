using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Role;
using Demo.Domain.Entities;

namespace Demo.Application.Mapper.RoleMapper
{
    public class RoleMapperResponse
    {
        /// <summary>
        /// Convert Role object to GetRoleResponse object
        /// </summary>
        /// <param name="role">Role Entity Value</param>
        /// <returns>
        /// GetRoleResponse Object
        /// </returns>
        public static GetRoleResponse GetRoleMapEntityToDTO(Role role)
        {
            return new GetRoleResponse
            {
                RoleId = role?.RoleId,
                RoleName = role?.RoleName,
            };
        }

        /// <summary>
        /// Convert List<Role> to List<GetRoleResponse>
        /// </summary>
        /// <param name="roleList">List of role object</param>
        /// <returns>
        /// List of GetRoleResponse object
        /// </returns>
        public static List<GetRoleResponse> GetRoleListMapEntityToDTO(List<Role> roleList)
        {
            List<GetRoleResponse> roleListDTO = [];
            foreach (var role in roleList)
            {
                roleListDTO.Add(new GetRoleResponse
                {
                    RoleId = role?.RoleId,
                    RoleName = role?.RoleName,
                });
            }
            return roleListDTO;
        }
    }
}
