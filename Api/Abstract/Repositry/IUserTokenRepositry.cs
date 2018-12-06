using System.Threading.Tasks;
using Abstract.Entities;
using Framework.UnitOfWork;

namespace Abstract.Repositry
{
    public interface IUserTokenRepositry : IBasicRepositrory<UserTokens>
    {
        Task<UserTokens> GetUserTokens(int userId, string loginProvider, string name);
        Task<UserTokens> GetUserTokensWithProviderName(int userId, string loginProvider);
        Task<UserTokens> GetUserTokensWithTokenName(int userId, string name);
    }
}