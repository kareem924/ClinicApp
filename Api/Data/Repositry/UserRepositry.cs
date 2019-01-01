using System.Threading.Tasks;
using Abstract.Entities;
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

        public Task<bool> ActivateUser(int Id)
        {
            throw new System.NotImplementedException();
        }

      

        public Task<bool> DisactiveUser(int Id)
        {
            throw new System.NotImplementedException();
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