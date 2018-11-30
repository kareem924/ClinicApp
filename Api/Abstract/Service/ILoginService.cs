using System.Threading.Tasks;
using Abstract.Entities;
using Framework.Models.Result;

namespace Abstract.Service
{
    public interface ILoginService
    {
        Task<LoginResult> login(string userName, string password);
        Task<Users> Check(string name, string password);
        JwtResult GenerateToken(UserDto user);
    }
}