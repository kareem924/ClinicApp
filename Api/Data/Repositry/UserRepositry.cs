using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Infrastructure;
using Abstract.Repositry;

namespace Data.Repositry
{
    public class UserRepositry : DapperRepositry<Users>,IUserRepositry
    {
        public UserRepositry(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}