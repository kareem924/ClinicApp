using System.Threading.Tasks;
using Abstract.Entities;
using Dapper;
using Data.Repositry;
using Framework.Models;
using Xunit;

namespace IntegrationTest.Repositries
{
    public class LoginRepositoryTest : BaseRepositoryTest
    {
        private readonly LoginRepository _loginRepository;
        public LoginRepositoryTest()
        {

            _loginRepository = new LoginRepository(UnitOfWork);
        }
        [Fact]
        public async Task CheckAuthentactedUser_RightData_Success()
        {
            //Arrange
            string sql = @"select top 1 * FROM users where
            PasswordHash=@HashedPassword AND (Email=@userName OR UserName=@userName)";
            var loginModel = new LoginModel() {UserName = "kareem",Password = "Miko900"};
            //Act

            var dbUser = await UnitOfWork.Connection.QueryFirstOrDefaultAsync<Users>(sql, new { HashedPassword = loginModel.Password, userName = loginModel.UserName }, UnitOfWork.Transaction);
            var repoUser = await _loginRepository.CheckIsAuthorisedUserAsync(loginModel.UserName, loginModel.Password);

            //Assert
            Assert.NotNull(dbUser);
            Assert.NotNull(repoUser);
            Assert.Equal(dbUser.Id, repoUser.Id);
        }
    }
}
