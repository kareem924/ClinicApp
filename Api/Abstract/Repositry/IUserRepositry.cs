using System.Threading.Tasks;
using Abstract.Entities;
using Framework.UnitOfWork;

namespace Abstract.Repositry
{
    public interface IUserRepositry:IBasicRepositrory<Users>
    {
        Task<Users> CheckIsAuthorisedUserAsync(string userName, string hashedPassword);
        Task<bool> UptadePasswordAsync(string newPassword, Users user);
        Task<bool> ActivateEmailAsync(string activationCode,string email);
        Task<Users> GetByEmailAsync(string email);
        Task<bool> ActivateUser (int Id);
        Task<bool> DisactiveUser(int Id);


    }
}