using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Core.Models;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using EntertainmentDatabase.Services;
using EntertainmentDatabase.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.Web.Controllers
{
    [Authorize(AuthenticationSchemes = "Entertainment-Database")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UpcApiController : Controller
    {
        private IUpcDataManager UpcDataManager { get; }
        private IMovieWriteDataAccess MovieWriteDataAccess { get; }

        public UpcApiController(IUpcDataManager upcDataManager, IMovieWriteDataAccess movieWriteDataAccess)
        {
            UpcDataManager = upcDataManager;
            MovieWriteDataAccess = movieWriteDataAccess;
        }

        
        [HttpPost("[action]")]
        public async Task<UpcItemDbDto> GetDetailsByUpc([FromBody] UpcApiRequest request)
        {
            var claims = GetUniqueIdClaimInt64(User);
            return await UpcDataManager.GetItemDetailsFromExternalApi(request.Upc);
        }

        [HttpPost("[action]")]
        public async Task SaveNewMovie([FromBody] SaveNewMovieRequest request)
        {
            await MovieWriteDataAccess.SaveMovie(new MovieModel
            {
                Upc = request.Upc,
                Ean = request.Ean,
                Description = request.Description,
                Title = request.Title
            });
        }
        
        
        public static string GetUniqueIdClaimString(ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(c => c.Type == "UniqueId")?.Value;
        }

        public static long? GetUniqueIdClaimInt64(ClaimsPrincipal principal)
        {
            string rawClaimValue = principal.Claims.FirstOrDefault(c => c.Type == "UniqueId")?.Value;
            long? value = !String.IsNullOrWhiteSpace(rawClaimValue) ? Convert.ToInt64(rawClaimValue) : (long?)null;

            return value;
        }
    }
}