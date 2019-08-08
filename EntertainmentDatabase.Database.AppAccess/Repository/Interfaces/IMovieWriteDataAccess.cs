using System.Threading.Tasks;
using EntertainmentDatabase.Core.Models;

namespace EntertainmentDatabase.Database.AppAccess.Repository.Interfaces
{
    public interface IMovieWriteDataAccess
    {
        Task SaveMovie(MovieModel movie);
    }
}