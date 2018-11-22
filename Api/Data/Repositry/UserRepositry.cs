using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Infrastructure;
using Abstract.Repositry;
using Dapper;
using Framework.Extensions;

namespace Data.Repositry
{
    public class UserRepositry : DapperRepositry<Users>, IUserRepositry
    {
        public UserRepositry(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<bool> ActivateEmailAsync(string activationCode, string email)
        {
            
            throw new System.NotImplementedException();
        }

        public async Task<Users> CheckIsAuthorisedUserAsync(string userName, string hashedPassword)
        {
            string sql = @"select top 1 * FROM users where
            PasswordHash=@HashedPassword AND (Email=@userName OR UserName=@userName)";
            using (var connection = _connectionFactory.GetConnection)
            {
                Users userByUsernameOrEmail = null;
                userByUsernameOrEmail = await connection.QueryFirstOrDefaultAsync<Users>(sql, new { HashedPassword = hashedPassword, userName = userName });

                return userByUsernameOrEmail;

            }
        }

        public async Task<Users> GetByEmailAsync(string email)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                return await connection.QuerySingleAsync<Users>(@"Select top 1 FROM users where  Email=" + email);

            }
        }

        public async Task<bool> UptadePasswordAsync(string newPassword, Users user)
        {

            string sql = "UPDATE Users SET EncryptedPassword = @newPassword WHERE Id = @Id;";
            using (var connection = _connectionFactory.GetConnection)
            {
               
                int affectedRows = await connection.ExecuteAsync(sql,new {newPassword=newPassword.ToMD5Hash(),Id=user.Id});
                 return affectedRows >0;
            }
        }

       
    }
}