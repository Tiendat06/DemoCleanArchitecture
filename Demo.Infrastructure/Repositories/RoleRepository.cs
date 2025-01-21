using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Demo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Role>> getAllRoles()
        {
            return await _appDbContext.Role
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Role?> getRoleById(int id)
        {
            return await _appDbContext.Role
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RoleId == id);
        }
    }
}
