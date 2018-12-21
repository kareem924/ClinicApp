using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common;
using Framework.Models;
using Xunit;

namespace IntegrationTest.Controller
{
   
    public class SecurityControllerTest : ServerFixture
    {

        [Fact]
        public async Task Login_RegisteredUser_AbleToLogin()
        {
            var loginData = new LoginModel
            {
                UserName = Email,
                Password = Password,
                LoginProvider = "Web"
            };
            // Act
            var response = await PostAsync("/api/Security/Login", loginData);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
