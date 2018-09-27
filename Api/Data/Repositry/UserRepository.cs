using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Infrastructure;
using Abstract.Repositry;
using Dapper;
namespace Data.Repositry
{
    public class UserRepository : IUserRepositry
    {
        IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory=connectionFactory;
        }
        public User Add(User t)
        {
           const string sql = "INSERT INTO Users (Name,Email,IsDeleted) Values (@Name,@Email,@IsDeleted)";

            using (var connection = _connectionFactory.GetConnection)
            {
                Console.WriteLine(connection.State);
                var affectedRows = connection.Execute(sql, new User(){ Name = "Mark",Email="Mark@mark.com",IsDeleted=false,CreatedAt=DateTime.Now,CreatedBy=1,ModifiedAt=DateTime.Now,ModifiedBy=2 });

                Console.WriteLine(affectedRows);

                var customer = connection.QuerySingle<User>("Select * FROM Users where Id = 1");

               return customer;
            }
        }

        public IEnumerable<User> AddAll(IEnumerable<User> tList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> AddAllAsync(IEnumerable<User> tList)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddAsync(User t)
        {
            throw new NotImplementedException();
        }

        public void Attach(User t)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<User, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<User, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public User Find(Expression<Func<User, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> FindAll(Expression<Func<User, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> FindAll<TKey>(Expression<Func<User, bool>> match, int take, int skip, Expression<Func<User, TKey>> orderBy, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> FindAllAsync(Expression<Func<User, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> FindAllAsync<TKey>(Expression<Func<User, bool>> match, int take, int skip, Expression<Func<User, TKey>> orderBy, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(Expression<Func<User, bool>> match, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public User Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public User Update(User updated, object key)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User updated, object key)
        {
            throw new NotImplementedException();
        }
    }
}