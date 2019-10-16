using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using EntertainmentDatabase.Web.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginApiController : Controller
    {
        private IUserReadDataAccess UserReadDataAccess { get; }
        private IUserWriteDataAccess UserWriteDataAccess { get; }

        public LoginApiController(IUserReadDataAccess userReadDataAccess, IUserWriteDataAccess userWriteDataAccess)
        {
            UserReadDataAccess = userReadDataAccess;
            UserWriteDataAccess = userWriteDataAccess;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task Login([FromBody] LoginRequest request)
        {
            var user = new UserDetailsDto {Username = request.Username, Password = request.Password};

            var foundUser = await UserReadDataAccess.ValidateUserLogin(user);

            if (foundUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("UniqueId", foundUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, foundUser.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Entertainment-Database");

                await HttpContext.SignInAsync(
                    "Entertainment-Database",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        // todo commented out lines are for implementing a remember me option
                        //IsPersistent = request.IsRememberMeChecked,
                        //ExpiresUtc = request.IsRememberMeChecked ? DateTime.UtcNow.AddSeconds(AuthenticationOptions.Value.PersistentCookieExpirationInSeconds) : (DateTimeOffset?)null
                        AllowRefresh = true
                    });
                // Implement remember later
                /*HttpContext.Response.Cookies.Append(
                    CookieNames.RememberMeCookieName, 
                    request.IsRememberMeChecked ? "1" : "0",
                    new CookieOptions
                    {
                        Secure = true,
                        HttpOnly = true,
                        Path = "/",
                        SameSite = SameSiteMode.Lax,
                        Expires = DateTime.UtcNow.AddSeconds(AuthenticationOptions.Value.RememberMeCookieExpirationInSeconds)
                    }
                );*/
            }
        }

        [HttpPost("[action]")]
        public async Task CreateUser(CreateUserRequest request)
        {
            var user = new UserDetailsDto
            {
                Username = request.Username,
                Password = request.Password
            };

            await UserWriteDataAccess.CreateNewUser(user);
        }
    }
}