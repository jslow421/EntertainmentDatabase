using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;

namespace EntertainmentDatabase.Database.AppAccess.Repository.Interfaces
{
    public interface IUserWriteDataAccess
    {
        Task CreateNewUser(UserDetailsDto user);
    }
}