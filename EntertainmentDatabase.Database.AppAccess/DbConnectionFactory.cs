using System.Threading.Tasks;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using MySql.Data.MySqlClient;

namespace EntertainmentDatabase.Database.AppAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private string ConnectionString { get; }

        public DbConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString; // todo include both connection strings
        }

        public async Task<MySqlConnection> GetOpenMySqlConnectionAsync()
        {
            var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync().ConfigureAwait(false);
            return connection;
        }
    }
}