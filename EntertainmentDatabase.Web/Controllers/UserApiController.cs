using System;
using System.Net;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Services;
using EntertainmentDatabase.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : Controller
    {
        private IUserService UserService { get; }
        
        public UserApiController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task Authenticate([FromBody] LoginRequest loginRequest)
        {
            var user = new UserDetailsDto
            {
                Username = loginRequest.Username,
                Password = loginRequest.Password
            };

            var result = await UserService.Authenticate(user.Username, user.Password);

            // todo move some of this token config stuff to appsettings
            Response.Cookies.Append("token", result.Token,
                new CookieOptions{HttpOnly = true, Expires = DateTimeOffset.Now.AddDays(14), Secure = true});
        }
    }
}