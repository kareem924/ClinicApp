using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Dapper;
using Framework.UnitOfWork;

namespace Data.Repositry
{
    public class LoginRepository : ILoginRepositry
    {
        readonly IUnitOfWork _unitOfWork;
        public LoginRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Users> CheckIsAuthorisedUserAsync(string userName, string hashedPassword)
        {
            string sql = @"select top 1 * FROM users where
            PasswordHash=@HashedPassword AND (Email=@userName OR UserName=@userName)";
            Users userByUsernameOrEmail = null;
            userByUsernameOrEmail = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Users>(sql, new { HashedPassword = hashedPassword, userName = userName },_unitOfWork.Transaction);
            return userByUsernameOrEmail;
        }


       
    }
}