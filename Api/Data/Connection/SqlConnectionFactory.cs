using System;
using System.Data;
using System.Data.Common;
using Abstract.Infrastructure;
using System.Data.SqlClient;


namespace Data.Connection
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection
        {
            get
            {
                 Console.WriteLine(string.IsNullOrEmpty(_connectionString));
                Console.WriteLine(_connectionString);
                try {DbConnection conn = new SqlConnection(_connectionString);
               // conn.ConnectionString = _connectionString;
                conn.Open();
                return conn;}
                catch(Exception e){
                    Console.WriteLine(e);
                    return null;
                }
                
            }
        }


    }
}