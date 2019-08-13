using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EntertainmentDatabase.Services
{
    public class UserService : IUserService
    {
        // todo dump this test after implementing actual user table
        private List<UserDetailsDto> _users = new List<UserDetailsDto> 
        {
            new UserDetailsDto { Username = "john", Password = "password" } 
        };

        private readonly ServicesConfiguration _config; // todo inject this value rather than the whole config

        public UserService(IOptions<ServicesConfiguration> appSettings)
        {
            _config = appSettings.Value;
        }
        
        public async Task<UserDetailsDto> Login()
        {

            return null;
        }

        public async Task<UserDetailsDto> Authenticate(string username, string password)
        {
            /*var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;*/
            return null;
        }
    }
}