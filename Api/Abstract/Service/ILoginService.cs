using System.Threading.Tasks;
using Abstract.Entities;
using Framework.Models;
using Framework.Models.Result;

namespace Abstract.Service
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginModel model);
        Task<Users> Check(string name, string password);
        JwtResult GenerateToken(UserDto user);
        Task UpdateUserTokenInDb(int userId, string providerName,string token);
    }
}