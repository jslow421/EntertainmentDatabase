using System.Threading.Tasks;
using Dapper;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EntertainmentDatabase.Database.AppAccess.Repository
{
    public class UserReadDataAccess : IUserReadDataAccess
    {
        private IDbConnectionFactory DbConnectionFactory { get; }
        private IPasswordHasher<UserDetailsDto> PasswordHasher { get; }

        public UserReadDataAccess(IDbConnectionFactory dbConnectionFactory, IPasswordHasher<UserDetailsDto> passwordHasher)
        {
            DbConnectionFactory = dbConnectionFactory;
            PasswordHasher = passwordHasher;
        }

        public async Task<UserDetailsDto> ValidateUserLogin(UserDetailsDto user)
        {
            var hashedPassword = await GetHashedPasswordFromTable(user.Username);
            var result = PasswordHasher.VerifyHashedPassword(user, hashedPassword,user.Password);

            if (result == PasswordVerificationResult.Success)
            {
                return await GetUserInfo(user.Username);
            }

            return new UserDetailsDto();
        }
        
        private async Task<string> GetHashedPasswordFromTable(string username)
        {
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                return await connection.QueryFirstOrDefaultAsync<string>(
                    "SELECT password FROM app_users WHERE username = @Username", 
                    new
                    {
                        Username = username
                    });
            }
        }
        
        private async Task<UserDetailsDto> GetUserInfo(string username)
        {
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                return await connection.QueryFirstOrDefaultAsync<UserDetailsDto>(
                    "SELECT * FROM app_users WHERE username = @Username", 
                    new
                    {
                        Username = username
                    });
            }
        }
    }
}