using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using EntertainmentDatabase.Core.Models;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;

namespace EntertainmentDatabase.Database.AppAccess.Repository
{
    public class MovieReadDataAccess : IMovieReadDataAccess
    {
        private IDbConnectionFactory DbConnectionFactory { get; }
        
        public MovieReadDataAccess(IDbConnectionFactory dbConnectionFactory)
        {
            DbConnectionFactory = dbConnectionFactory;
        }

        public async Task<MovieModel> GetMovieByUpc(int upc)
        {
            MovieModel result;
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                result = await connection.QueryFirstOrDefaultAsync<MovieModel>(
                    "SELECT * FROM movies WHERE upc = @UPC", 
                    new
                    {
                        UPC = upc
                    });
            }
            
            return result;
        }
        
        public async Task<MovieModel> GetMovieById(int id)
        {
            MovieModel result;
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                result = await connection.QueryFirstOrDefaultAsync<MovieModel>(
                    "SELECT * FROM movies WHERE id = @Id", 
                    new
                    {
                        Id = id
                    });
            }
            
            return result;
        }

        public async Task<IEnumerable<MovieModel>> GetAllMovies()
        {
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                return await connection.QueryAsync<MovieModel>(
                    "SELECT * FROM movies");
            }
        }
    }
}