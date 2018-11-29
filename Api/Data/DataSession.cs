using Abstract.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public sealed class DataSession : IDisposable
    {
        IDbConnection _connection = null;
        DapperUnitOfWork _unitOfWork = null;
        public IConnectionFactory _connectionFactory;
        public DataSession(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.GetConnection;
            _connection.Open();
            _unitOfWork = new DapperUnitOfWork(_connectionFactory);
        }

        public DapperUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}
