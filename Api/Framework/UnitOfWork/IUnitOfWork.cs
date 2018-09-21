using System;
using System.Threading.Tasks;

namespace Framework.UnitOfWork
{
     public interface IUnitOfWork : IDisposable
    {
        void Commit(string successMessage = null);
        Task CommitAsync();
        IRepository<T> GetGenRepo<T>() where T : class;


    }
}
