using System.Net;
using System.Threading.Tasks;
using Framework.Models;
using Framework.Models.Result;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTest.Controller
{
   
    public class SecurityControllerTest : ServerFixture
    {

       
        [Fact]
        public async Task Login_Failed_LoginWithWrongData()
        {

            var loginData = new LoginModel
            {
                UserName = "khaled",
                Password = "123456",
                LoginProvider = "Web"
            };
            // Act
            var response = await PostAsync("/api/Security/Login", loginData);
            var contents = await response.Content.ReadAsStringAsync();
            LoginResult businessunits = JsonConvert.DeserializeObject<LoginResult>(contents);

            //Assert
            Assert.False(businessunits.IsAuhtentaced);
        }

        [Fact]
        public async Task Login_success_loginWithRightData()
        {
            var loginData = new LoginModel
            {
                UserName = "kareem",
                Password = "MIKO900",
                LoginProvider = "Web"
            };
            // Act
            var response = await PostAsync("/api/Security/Login", loginData);
            var contents = await response.Content.ReadAsStringAsync();
            LoginResult businessunits = JsonConvert.DeserializeObject<LoginResult>(contents);

            //Assert
            Assert.True(businessunits.IsAuhtentaced);
        }
    }
}
