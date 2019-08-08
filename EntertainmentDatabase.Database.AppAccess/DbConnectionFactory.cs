using System.Threading.Tasks;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using MySql.Data.MySqlClient;

namespace EntertainmentDatabase.Database.AppAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private string ConnectionString { get; set; }

        public DbConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<MySqlConnection> GetOpenMySqlConnectionAsync()
        {
            var connection = new MySqlConnection(ConnectionString);

            await connection.OpenAsync().ConfigureAwait(false);

            return connection;
        }
    }
}