using System.Data.SqlClient;
using Abstract.Infrastructure;

namespace Data.Connection
{
    public class SqlConnectionFactory: IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        

        object IConnectionFactory.CreateConnection()
        {
             var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}