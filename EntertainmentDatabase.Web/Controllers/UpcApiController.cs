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

        [Authorize]
        [HttpPost("[action]")]
        public async Task<UpcItemDbDto> GetDetailsByUpc([FromBody] UpcApiRequest request)
        {
            var result = await UpcDataManager.GetItemDetailsFromExternalApi(request.Upc);

            return result;
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
    }
}