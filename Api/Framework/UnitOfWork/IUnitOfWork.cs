using System;
using System.Data;
using System.Threading.Tasks;

namespace Framework.UnitOfWork
{
     public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Rollback();
        IRepository<T> GetGenRepoFor<T>() where T : class;
    }
}
