using System.Threading.Tasks;
using Abstract.Entities;
using Dapper;
using Framework.UnitOfWork;

namespace Data.Repositry
{
    public class UserTokenRepositry : DapperRepositry<UserTokens>
    {
         private readonly IUnitOfWork _unitOfWork;
        public UserTokenRepositry(IUnitOfWork ouw) : base(ouw)
        { _unitOfWork = ouw;
        }
         public async Task<UserTokens> GetUserTokens(int userId, string loginProvider, string name)
        {
           const string sql = @"select * FROM UserTokens where
            userId =@userId AND
            LoginProvider =@LoginProvider AND
            Name =@name";
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserTokens>(sql, new { userId ,loginProvider,name},_unitOfWork.Transaction);
        }
        public async Task<UserTokens> GetUserTokensWithProviderName(int userId, string loginProvider)
        {
            const string sql = @"select * FROM UserTokens where
            userId =@userId AND
            LoginProvider =@LoginProvider";
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserTokens>(sql, new { userId ,loginProvider},_unitOfWork.Transaction);
        }
        public async Task<UserTokens> GetUserTokensWithTokenName(int userId, string name)
        {
             const string sql = @"select * FROM UserTokens where
            userId =@userId AND
            Name =@name";
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserTokens>(sql, new { userId ,name},_unitOfWork.Transaction);
        }
    }
}