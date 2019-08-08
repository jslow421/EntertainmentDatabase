using System.Collections.Generic;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Models;

namespace EntertainmentDatabase.Database.AppAccess.Repository.Interfaces
{
    public interface IMovieReadDataAccess
    {
        Task<MovieModel> GetMovieByUpc(int upc);
        Task<MovieModel> GetMovieById(int id);
        Task<IEnumerable<MovieModel>> GetAllMovies();
    }
}