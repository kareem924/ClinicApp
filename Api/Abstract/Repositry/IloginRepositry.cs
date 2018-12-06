using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;

namespace Abstract.Repositry
{
    public interface IloginRepositry
    {
        Task<Users> CheckIsAuthorisedUserAsync(string userName, string hashedPassword);
     
    }
}