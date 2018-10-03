using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.UnitOfWork
{
    public interface IBasicRepositrory<T>
    {

        T Get(object id);
        IEnumerable<T> All ();
        T Insert(T t);
        bool Update(T t);
        bool Delete(T t);

         Task<T> GetAsync(object id);
        Task<IEnumerable<T>> AllAsync ();
        Task<T> InsertAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<bool> DeleteAsync(T t);
    }
}