using System;
using System.Net;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UpcApiController : Controller
    {
        [HttpGet("[action]")]
        public async Task GetDetailsByUpc()
        {
            // update return type when that object is created
        }
}
}