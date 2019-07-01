using System.Collections.Generic;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Models;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using MongoDB.Driver;

namespace EntertainmentDatabase.Database.AppAccess.Repository
{
    public class MoviesMongoDbRepository : IMoviesMongoDbRepository
    {
        private readonly IMongoCollection<MovieModel> _movies;
        
        public MoviesMongoDbRepository(IMoviesMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movies = database.GetCollection<MovieModel>(settings.MoviesCollectionName);
        }
        
        public List<MovieModel> GetAllMovies() =>
            _movies.Find(movie => true).ToList();
        
        public async Task<MovieModel> AddMovie(MovieModel movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

    }
}