using System.Collections.Generic;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Models;

namespace EntertainmentDatabase.Database.AppAccess.Repository.Interfaces
{
    public interface IMoviesMongoDbRepository
    {
        List<MovieModel> GetAllMovies();
        Task<MovieModel> AddMovie(MovieModel movie);
    }
}