using System.Collections.Generic;
using Abstract.Entities;
using Abstract.Infrastructure;
using Framework.UnitOfWork;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositry
{
    public class DapperRepositry<T> : IBasicRepositrory<T> where T : class
    {
       public IConnectionFactory _connectionFactory;
        public DapperRepositry(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public IEnumerable<T> All()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var all = connection.GetAll<T>();
                return all;
            }
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var all = await connection.GetAllAsync<T>();
                return all;
            }
        }

        public bool Delete(T id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var all = connection.Delete<T>(id);
                return all;
            }
        }

        public async Task<bool> DeleteAsync(T t)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var all = await connection.DeleteAsync<T>(t);
                return all;
            }
        }

        public T Get(object id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var obj = connection.Get<T>(id);
                return obj;
            }
        }

        public async Task<T> GetAsync(object id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var obj = await connection.GetAsync<T>(id);
                return obj;
            }
        }

        public T Insert(T t)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var obj = connection.Insert<T>(t);
                var insertedObj = connection.QuerySingle<T>(@"Select * FROM " + typeof(T).Name + " where Id =" + obj);
                return insertedObj;
            }
        }

        public async Task<T> InsertAsync(T t)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var obj = await connection.InsertAsync<T>(t);
                var insertedObj = await connection.QuerySingleAsync<T>(@"Select * FROM " + typeof(T).Name + " where Id =" + obj);
                return insertedObj;
            }
        }

        public bool Update(T t)
        {
             using (var connection = _connectionFactory.GetConnection)
            {
                var obj = connection.Update<T>(t);
                return obj;
            }
        }

        public async Task<bool> UpdateAsync(T t)
        {
           using (var connection = _connectionFactory.GetConnection)
            {
                var obj = await connection.UpdateAsync<T>(t);
                return obj;
            }
        }
    }
}