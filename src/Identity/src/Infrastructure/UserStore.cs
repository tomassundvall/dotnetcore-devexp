using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using TSundvall.DotnetCoreDevExp.Identity.Model;

namespace TSundvall.DotnetCoreDevExp.Identity.Infrastructure
{
    public class UserStore : IUserStore<AppUser>
    {
        private readonly string _connectionString;

        public UserStore(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        public async Task<IdentityResult> CreateAsync(
            AppUser user,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var sql = 
                @"INSERT INTO ApplicationUser
                (
                    UserName,
                    NormalizedUserName,
                    Email,
                    NormalizedEmail,
                    EmailConfirmed,
                    PasswordHash,
                    PhoneNumber,
                    PhoneNumberConfirmed,
                    TwoFactorEnabled
                ) VALUES (
                    @UserName,
                    @NormalizedUserName,
                    @Email,
                    @NormalizedEmail,
                    0,
                    @PasswordHash,
                    @PhoneNumber,
                    0,
                    0
                ); SELECT last_insert_rowid();";

            // using (var cn = new SqliteConnection(_connectionString))
            // {
            //     user.Id = (await cn.QueryAsync<int>(sql, new {
            //         UserName = 
            //     })).First();
            // }

           return IdentityResult.Success;
        }


        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }


        public Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }


        public void Dispose()
        {
            // Nothing to dispose...
        }
    }
}