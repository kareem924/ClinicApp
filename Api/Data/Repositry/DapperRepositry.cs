using System.Collections.Generic;
using Framework.UnitOfWork;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

namespace Data.Repositry
{
    public class DapperRepositry<T> : IBasicRepositrory<T> where T : class
    {
        public IUnitOfWork _ouw;
        public DapperRepositry(IUnitOfWork ouw)
        {
            _ouw = ouw;
        }
        public IEnumerable<T> All()
        {
            return _ouw.Connection.GetAll<T>(_ouw.Transaction);

        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            return await _ouw.Connection.GetAllAsync<T>(_ouw.Transaction);

        }

        public bool Delete(T id)
        {
            return _ouw.Connection.Delete<T>(id, _ouw.Transaction);

        }

        public async Task<bool> DeleteAsync(T t)
        {
            return await _ouw.Connection.DeleteAsync<T>(t, _ouw.Transaction);

        }

        public T Get(object id)
        {
            return _ouw.Connection.Get<T>(id, _ouw.Transaction);

        }

        public async Task<T> GetAsync(object id)
        {
            return await _ouw.Connection.GetAsync<T>(id, _ouw.Transaction);
        }

        public T Insert(T t)
        {
            var obj = _ouw.Connection.Insert<T>(t, _ouw.Transaction);
            var insertedObj = _ouw.Connection.QueryFirstOrDefault<T>(@"Select * FROM " + typeof(T).Name + " where Id =" + obj, _ouw.Transaction);
            return insertedObj;

        }

        public async Task<T> InsertAsync(T t)
        {

            var obj = await _ouw.Connection.InsertAsync<T>(t, _ouw.Transaction);
            var insertedObj = await _ouw.Connection.QueryFirstOrDefaultAsync<T>(@"Select * FROM " + typeof(T).Name + " where Id =" + obj, _ouw.Transaction);
            return insertedObj;
        }

        public bool Update(T t)
        {
            return _ouw.Connection.Update<T>(t, _ouw.Transaction);

        }

        public async Task<bool> UpdateAsync(T t)
        {
            return await _ouw.Connection.UpdateAsync<T>(t, _ouw.Transaction);
        }
    }
}