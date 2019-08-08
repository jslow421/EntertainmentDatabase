using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;

namespace EntertainmentDatabase.Services
{
    public interface IUserService
    {
        Task<UserDetailsDto> Authenticate(string username, string password);
    }
}