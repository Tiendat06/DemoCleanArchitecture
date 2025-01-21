using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.User;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Demo.Application.Mapper.UserMapper
{
    public class UserMapperResponse
    {
        /// <summary>
        /// Convert User object to GetUserResponse object
        /// </summary>
        /// <param name="user">An entity: User</param>
        /// <returns>
        /// GetUserResponse object
        /// </returns>
        public static GetUserResponse GetUserMapEntityToDTO(User user)
        {
            return new GetUserResponse
            {
                UserId = user?.UserId,
                Name = user?.Name,
                Email = user?.Email,
                UserName = user?.Account?.UserName,
                //Password = user?.Account?.Password,
                CreatedAt = user?.CreatedAt,
                UpdatedAt = user?.UpdatedAt,
                IsDeleted = user?.IsDeleted,
                DeletedAt = user?.DeletedAt,
                AccountId = user?.AccountId,
                RoleName = user?.Account?.Role?.RoleName,
            };
        }

        /// <summary>
        /// Convert List<User> to List<GetUserResponse>
        /// </summary>
        /// <param name="users">List of User object</param>
        /// <returns>
        /// List of GetUserResponse object
        /// </returns>
        public static List<GetUserResponse> GetUserListMapEntityToDTO(List<User> users) 
        {
            List<GetUserResponse> userListDTO = [];
            foreach (var user in users) 
            {
                userListDTO.Add(new GetUserResponse
                {
                    UserId = user?.UserId,
                    Name = user?.Name,
                    Email = user?.Email,
                    UserName = user?.Account?.UserName,
                    //Password = user?.Account?.Password,
                    CreatedAt = user?.CreatedAt,
                    UpdatedAt = user?.UpdatedAt,
                    IsDeleted = user?.IsDeleted,
                    DeletedAt = user?.DeletedAt,
                    AccountId = user?.AccountId,
                    RoleName = user?.Account?.Role?.RoleName,
                });
            }
            return userListDTO;
        }
    }
}
