using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Services;
using EntertainmentDatabase.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UpcApiController : Controller
    {
        private IUpcDataManager UpcDataManager { get; }

        public UpcApiController(IUpcDataManager upcDataManager)
        {
            UpcDataManager = upcDataManager;
        }

        [HttpPost("[action]")]
        public async Task<UpcItemDbDto> GetDetailsByUpc([FromBody] UpcApiRequest request)
        {
            var result = await UpcDataManager.GetItemDetailsFromExternalApi(request.Upc);

            return result;
        }
    }
}