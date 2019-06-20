using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;

namespace EntertainmentDatabase.Services
{
    public interface IUpcDataManager
    {
        Task<UpcItemDbDto> GetItemDetailsFromExternalApi(string upc);
    }
}