using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Demo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Account?> AddAccountAsync(Account account)
        {
            await _appDbContext.Account.AddAsync(account);
            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0 ? account : null;
        }

        public async Task<bool> SoftDeleteAccountAsync(Account account)
        {
            _appDbContext.Entry(account).Property(u => u.IsDeleted).IsModified = true;
            _appDbContext.Entry(account).Property(u => u.DeletedAt).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0;
        }

        public async Task<bool> HardDeleteAccountAsync(int id)
        {
            _appDbContext.Account.Remove(new Account { AccountId = id });
            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0;
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _appDbContext.Account
                .AsNoTracking()
                .Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.AccountId == id && a.IsDeleted == false);
        }

        public async Task<List<Account>> GetAccountListAsync()
        {
            return await _appDbContext.Account
                .AsNoTracking()
                .Where(a => a.IsDeleted == false)
                .Include(a => a.Role)
                .ToListAsync();
        }

        public async Task<Account?> UpdateAccountAsync(Account account)
        {
            _appDbContext.Entry(account).Property(a => a.UserName).IsModified = true;
            _appDbContext.Entry(account).Property(a => a.UpdatedAt).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0? account : null;
        }

        public async Task<Account?> UpdateAccountRoleAsync(Account account)
        {
            _appDbContext.Entry(account).Property(a => a.RoleId).IsModified = true;
            _appDbContext.Entry(account).Property(a => a.UpdatedAt).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0? account: null;
        }

        public async Task<bool> UpdateAccountPasswordToEmailAsync(Account account)
        {
            _appDbContext.Entry(account).Property(a => a.Password).IsModified = true;

            var affectedRow = await _appDbContext.SaveChangesAsync();
            return affectedRow > 0? true: false;
        }
    }
}
