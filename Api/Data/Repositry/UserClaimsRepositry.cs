using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Dapper;
using Framework.UnitOfWork;

namespace Data.Repositry
{
    public class UserClaimsRepositry : DapperRepositry<UserClaims>, IUserClaimsRepositry
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserClaimsRepositry(IUnitOfWork ouw) : base(ouw)
        {
            _unitOfWork = ouw;
        }


        public async Task<IEnumerable<UserClaims>> GetUserClaims(int userId)
        {
            const string sql = @"select * FROM UserClaims where userId =@userId";
            return await _unitOfWork.Connection.QueryAsync<UserClaims>(sql, new { userId = userId }, _unitOfWork.Transaction);
        }
    }
}