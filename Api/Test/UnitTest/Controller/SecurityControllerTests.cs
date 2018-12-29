using System;
using System.Threading.Tasks;
using Abstract.Service;
using Framework.Models;
using Framework.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace UnitTest.Controller
{
    public class SecurityControllerTests
    {
        private readonly SecurityController _controller;
        private readonly Mock<ILoginService> _loginService;

        public SecurityControllerTests()
        {
            _loginService = new Mock<ILoginService>();
            var logger = new Mock<ILogger<SecurityController>>();
            _controller = new SecurityController(_loginService.Object, logger.Object);
        }
        [Fact]
        public async Task Get_WhenCalled_ReturnsBadRequest()
        {
            // Act
            var badRequestResult = await _controller.Login(new LoginModel());
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }
        [Fact]
        public async Task Get_WhenCalled_OkRequest()
        {
            // Act
            var okRequestResult = await _controller.Login(new LoginModel()
            {
                LoginProvider = "web",
                UserName = "userName",
                Password = "password"
            });
            // Assert
            Assert.IsType<OkObjectResult>(okRequestResult.Result);
        }

        [Fact]
        public async Task LoginTest_ReturnsOkIsAuthentacted_WhencredentialExists()
        {
            var model = new LoginModel()
            {
                LoginProvider = "web",
                UserName = "userName",
                Password = "password"
            };
            // Arrange
            _loginService.Setup(srv => srv.Login(model)).ReturnsAsync(() => new LoginResult()
            {
                Token = new JwtResult()
                {
                    Token = "fakeToken",
                    ExpiredToken = DateTime.Now
                },
                IsAuhtentaced = true,
                Message = "success"
            });


            // Act
            var result = await _controller.Login(model);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var value = okResult.Value as LoginResult;
            Assert.True(value != null && value.IsAuhtentaced);
        }


        [Fact]
        public async Task LoginTest_ReturnsOkIsNotAuthentacted_WhencredentialNotExists()
        {
            var model = new LoginModel()
            {
                LoginProvider = "web",
                UserName = "userName",
                Password = "password"
            };
            // Arrange
            _loginService.Setup(srv => srv.Login(model)).ReturnsAsync(() => new LoginResult()
            {
                Token = new JwtResult()
                {
                    Token = "fakeToken",
                    ExpiredToken = DateTime.Now
                },
                IsAuhtentaced = true,
                Message = "success"
            });

            model.Password = "wrongPassword";
            model.UserName = "wrongUserName";

            // Act
            var result = await _controller.Login(model);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            var value = okResult.Value as LoginResult;
            Assert.True(value != null && value.IsAuhtentaced);
        }
    }


}
