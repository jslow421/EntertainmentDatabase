using EntertainmentDatabase.Core.Dto;

namespace EntertainmentDatabase.Services
{
    public interface IUserService
    {
        UserDetailsDto Authenticate(string username, string password);
    }
}