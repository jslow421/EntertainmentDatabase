using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EntertainmentDatabase.Database.AppAccess.Repository.Interfaces
{
    public interface IDbConnectionFactory
    {
        Task<MySqlConnection> GetOpenMySqlConnectionAsync();
    }
}