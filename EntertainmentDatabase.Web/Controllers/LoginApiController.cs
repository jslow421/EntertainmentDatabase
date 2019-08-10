using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
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
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task Login([FromBody] LoginRequest request)
        {
            var foundUser = new UserDetailsDto
            {
                Username = request.Username,
                Password = request.Password,
                Email =  request.Username,
                Id = 1
            };
            
            var claims = new List<Claim>
            {
                new Claim("UniqueId", foundUser.Id.ToString()),
                new Claim(ClaimTypes.Name, foundUser.Email),
                new Claim("FullName", foundUser.Username)
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, "Entertainment-Database");

            await HttpContext.SignInAsync(
                "Entertainment-Database",
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    //IsPersistent = request.IsRememberMeChecked,
                    //ExpiresUtc = request.IsRememberMeChecked ? DateTime.UtcNow.AddSeconds(AuthenticationOptions.Value.PersistentCookieExpirationInSeconds) : (DateTimeOffset?)null
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
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
}