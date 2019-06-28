using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using EntertainmentDatabase.Services;
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

        [HttpGet("[action]")]
        public async Task<UpcItemDbDto> GetDetailsByUpc()
        {
            var result = await UpcDataManager.GetItemDetailsFromExternalApi("786936816365");

            return result;
        }
    }
}