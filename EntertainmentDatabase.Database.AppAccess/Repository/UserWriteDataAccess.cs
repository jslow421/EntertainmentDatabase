using System.Threading.Tasks;
using Dapper;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EntertainmentDatabase.Database.AppAccess.Repository
{
    public class UserWriteDataAccess : IUserWriteDataAccess
    {
        private IDbConnectionFactory DbConnectionFactory { get; }
        private IPasswordHasher<UserDetailsDto> PasswordHasher { get; }

        public UserWriteDataAccess(IDbConnectionFactory dbConnectionFactory, IPasswordHasher<UserDetailsDto> passwordHasher)
        {
            DbConnectionFactory = dbConnectionFactory;
            PasswordHasher = passwordHasher;
        }

        public async Task CreateNewUser(UserDetailsDto user)
        {
            var hashedPassword = PasswordHasher.HashPassword(user, user.Password);
            
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO app_users
                         (username, password) 
                        VALUES 
                         (@Username, @Password)", 
                    new
                    {
                        Username = user.Username,
                        Password = hashedPassword
                    });
            }
        }
    }
}