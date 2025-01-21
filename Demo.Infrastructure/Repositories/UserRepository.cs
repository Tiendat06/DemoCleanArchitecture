using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Interfaces;
using Demo.Domain.Entities;
using System.Linq.Expressions;
using Demo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public async Task<User?> AddUserAsync(User user)
        {
            await _appDbContext.User.AddAsync(user);
            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0 ? user : null;
        }

        public async Task<bool> SoftDeleteUserAsync(User user)
        {
            _appDbContext.Entry(user).Property(u => u.IsDeleted).IsModified = true;
            _appDbContext.Entry(user).Property(u => u.DeletedAt).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0;
        }

        public async Task<bool> HardDeleteUserAsync(int id)
        {
            _appDbContext.User.Remove(new User { UserId = id });
            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _appDbContext.User
                .AsNoTracking()
                .Include(u => u.Account)
                .ThenInclude(a => a.Role)
                .FirstOrDefaultAsync(u => u.UserId == id && u.IsDeleted == false);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.User
                .AsNoTracking()
                .Include(u => u.Account)
                .ThenInclude(a => a.Role)
                .FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
        }

        public async Task<User?> GetUserByEmailAndExceptUserIdAsync(string email, int userId)
        {
            return await _appDbContext.User
                .FirstOrDefaultAsync(user => user.Email == email && user.UserId != userId && user.IsDeleted == false);
        }

        public async Task<List<User>> GetListUserAsync()
        {
            return await _appDbContext.User
                .AsNoTracking()
                .Where(u => u.IsDeleted == false)
                .Include(u => u.Account)
                .ThenInclude(a => a.Role)
                .ToListAsync();
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            _appDbContext.Entry(user).Property(u => u.Name).IsModified = true;
            _appDbContext.Entry(user).Property(u => u.Email).IsModified = true;
            _appDbContext.Entry(user).Property(u => u.UpdatedAt).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0 ? user : null;
        }

        public async Task<User?> GetUserByAccountIdAsync(int accountId)
        {
            return await _appDbContext.User
                .AsNoTracking()
                .Include(u => u.Account)
                .ThenInclude(a => a.Role)
                .FirstOrDefaultAsync(u => u.AccountId == accountId);
        }
    }
}
