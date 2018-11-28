using Abstract.Infrastructure;
using Framework.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DapperUnitOfWork : IUnitOfWork

    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        public DapperUnitOfWork(IConnectionFactory connectionFactory)
        {

            _connection = connectionFactory.GetConnection;
        }
        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }
        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                
            }
        }
        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
        ~DapperUnitOfWork()
        {
            dispose(false);
        }
        public IRepository<T> GetGenRepoFor<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
