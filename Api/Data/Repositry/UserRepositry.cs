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
    public class UserRepositry : DapperRepositry<Users>,IUserRepositry
    {
        public UserRepositry(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Users Get(string userName, string hashedPassword)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                return connection.QuerySingle<Users>(@"Select top 1 FROM users where  UserName=" + userName + "and HashedPassword = "+hashedPassword.ToMD5Hash());
              
            }
        }

        public Users Get(string email)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                return connection.QuerySingle<Users>(@"Select top 1 FROM users where  Email=" + email);

            }
        }
    }
}