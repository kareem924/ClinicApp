using System.Threading.Tasks;
using Abstract.Entities;
using Framework.Models.Result;

namespace Abstract.Service
{
    public interface IAuthenticationService
    {
        Task<LoginResult> login(string userName, string password);
        Task<bool> ResetPassword(string email, string oldPassword, string newPassword);
        Task<bool> ForgetPassword(string email);
        Task<bool> ActivateEmail(string code);
        Task<Users> Check(string name, string password);
        JwtResult GenerateToken(UserDto user);
    }
}