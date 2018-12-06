using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Framework.UnitOfWork;

namespace Abstract.Repositry
{
    public interface IUserClaimsRepositry:IBasicRepositrory<UserClaims>
    {
         
        Task<IEnumerable<UserClaims>> GetUserClaims(int userId);
    }
}