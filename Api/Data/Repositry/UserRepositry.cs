using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Infrastructure;
using Abstract.Repositry;
using Dapper;
using Framework.Extensions;
using Framework.UnitOfWork;

namespace Data.Repositry
{
    public class UserRepositry : DapperRepositry<Users>, IUserRepositry
    {
        IUnitOfWork _unitOfWork;
        public UserRepositry(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActivateEmailAsync(string activationCode, string email)
        {

            throw new System.NotImplementedException();
        }

        public async Task<Users> CheckIsAuthorisedUserAsync(string userName, string hashedPassword)
        {
            string sql = @"select top 1 * FROM users where
            PasswordHash=@HashedPassword AND (Email=@userName OR UserName=@userName)";
            Users userByUsernameOrEmail = null;
            userByUsernameOrEmail = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Users>(sql, new { HashedPassword = hashedPassword, userName = userName });
            return userByUsernameOrEmail;


        }

        public async Task<Users> GetByEmailAsync(string email)
        {
            return await _unitOfWork.Connection.QuerySingleAsync<Users>(@"Select top 1 FROM users where  Email=" + email);

        }

        public async Task<bool> UptadePasswordAsync(string newPassword, Users user)
        {

            string sql = "UPDATE Users SET EncryptedPassword = @newPassword WHERE Id = @Id;";

            int affectedRows = await _unitOfWork.Connection.ExecuteAsync(sql, new { newPassword = newPassword.ToMD5Hash(), Id = user.Id });
            return affectedRows > 0;

        }


    }
}