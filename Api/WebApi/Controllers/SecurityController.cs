using System;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Logging;
using Framework.Models;
using Framework.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ILogger _logger;
        public SecurityController(ILoginService loginService, ILogger<SecurityController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }
         [HttpPost("Login")]
        public async Task<LoginResult> Login([FromBody]LoginModel model )
        {
            _logger.LogInformation(LoggingEvents.Loging, "Logging in", model.UserName);
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Bad Request");
                return new LoginResult {IsAuhtentaced=false,Message="",Token=null };

            }
            return await _loginService.Login(model);
        }
    }
}