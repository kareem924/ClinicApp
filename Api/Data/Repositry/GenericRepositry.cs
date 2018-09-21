
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abstract.Infrastructure;
using Framework.UnitOfWork;

using Dapper;
namespace Data.Repositry
{
   /* public class GenericRepositry<TObject> : IRepository<TObject> where TObject : class
    {

        private readonly IConnectionFactory _connectionFactory;
        public GenericRepositry(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// This method is responsible for ensuring that the connection is opened and closed safely and also ensures that we are always using an asynchronous connection.
        /// We open and close the connection with each method since SQL is going to manage our connection pooling and optimize this for us anyway
        /// We'll use a delegate here that matches a method that takes an argument of type IDbConnection and returns a Task of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="getData">Delegate that matches a method that takes an argument of type IDbConnection and returns a Task of type T</param>
        /// <returns>Task of type T - we'll be using this to build and execute our query</returns>
        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(
               @"Server=localhost;Database=ClinicApp;User Id=sa;Password=P@ssw0rd;"))
                {
                    
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }
        public TObject Add(TObject t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TObject> AddAll(IEnumerable<TObject> tList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TObject>> AddAllAsync(IEnumerable<TObject> tList)
        {
            throw new NotImplementedException();
        }

        public Task<TObject> AddAsync(TObject t)
        {
            throw new NotImplementedException();
        }

        public void Attach(TObject t)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TObject, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TObject, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Delete(TObject t)
        {
            throw new NotImplementedException();
        }

        public TObject Find(Expression<Func<TObject, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<TObject> FindAll<TKey>(Expression<Func<TObject, bool>> match, int take, int skip, Expression<Func<TObject, TKey>> orderBy, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TObject>> FindAllAsync<TKey>(Expression<Func<TObject, bool>> match, int take, int skip, Expression<Func<TObject, TKey>> orderBy, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<TObject> FindAsync(Expression<Func<TObject, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public TObject Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TObject> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public TObject Update(TObject updated, object key)
        {
            throw new NotImplementedException();
        }

        public Task<TObject> UpdateAsync(TObject updated, object key)
        {
            throw new NotImplementedException();
        }
    }*/
}