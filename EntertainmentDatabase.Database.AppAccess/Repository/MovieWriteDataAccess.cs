using System.Threading.Tasks;
using Dapper;
using EntertainmentDatabase.Core.Models;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;

namespace EntertainmentDatabase.Database.AppAccess.Repository
{
    public class MovieWriteDataAccess : IMovieWriteDataAccess
    {
        private IDbConnectionFactory DbConnectionFactory { get; }
        
        public MovieWriteDataAccess(IDbConnectionFactory dbConnectionFactory)
        {
            DbConnectionFactory = dbConnectionFactory;
        }

        public async Task SaveMovie(MovieModel movie)
        {
            using (var connection = await DbConnectionFactory.GetOpenMySqlConnectionAsync())
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO movies
                         (title, upc, ean, description) 
                        VALUES 
                         (@Title, @Upc, @Ean, @Description)", 
                    new
                    {
                        Title = movie.Title,
                        Upc = movie.Upc,
                        Ean = movie.Ean,
                        Description = movie.Description
                    });
            }
        }
    }
}