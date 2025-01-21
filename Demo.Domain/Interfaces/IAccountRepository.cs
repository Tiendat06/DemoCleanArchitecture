using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// This function is used to query to database, insert new account to Account table
        /// </summary>
        /// <param name="account">An entity: Account</param>
        /// <returns>
        /// Account Object
        /// </returns>
        Task<Account?> AddAccountAsync(Account account);

        /// <summary>
        /// This function is used to query to database, update specific account to Account table
        /// </summary>
        /// <param name="account">An entity: Account</param>
        /// <returns>
        /// Account Object
        /// </returns>
        Task<Account?> UpdateAccountAsync(Account account);

        /// <summary>
        /// This function is used to query to database, update specific account role from Account table
        /// </summary>
        /// <param name="account">An entity: Account</param>
        /// <returns>
        /// Account Object
        /// </returns>
        Task<Account?> UpdateAccountRoleAsync(Account account);

        /// <summary>
        /// This function is used to query to database, soft delete specific account from Account table
        /// </summary>
        /// <param name="account">An entity: Account</param>
        /// <returns>
        /// Boolean value
        /// </returns>
        Task<bool> SoftDeleteAccountAsync(Account account);

        /// <summary>
        /// This function is used to query to database, hard delete specific account by id from Account table
        /// </summary>
        /// <param name="id">A param data: account id</param>
        /// <returns>
        /// Boolean Value
        /// </returns>
        Task<bool> HardDeleteAccountAsync(int id);

        /// <summary>
        /// This function is used to query to database, get specific account by account id from Account table
        /// </summary>
        /// <param name="id">A param data: account id</param>
        /// <returns>
        /// Account Object
        /// </returns>
        Task<Account?> GetAccountByIdAsync(int id);

        /// <summary>
        /// This function is used to query to database, get all accounts from Account table
        /// </summary>
        /// <returns>
        /// List of Account Object
        /// </returns>
        Task<List<Account>> GetAccountListAsync();

        /// <summary>
        /// This function is used to query to database, update specific account password to the current email's account from Account table
        /// </summary>
        /// <param name="account">An entity: Account</param>
        /// <returns>
        /// Boolean Value
        /// </returns>
        Task<bool> UpdateAccountPasswordToEmailAsync(Account account);
    }
}
