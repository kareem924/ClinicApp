using System;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Logging;
using Framework.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private readonly ILogger _logger;
        public SecurityController(IAuthenticationService authenticationService, ILogger<SecurityController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }
         [HttpGet]
        public async Task<LoginResult> Login(string username,string password )
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Logging in", username);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Bad Request");
                return new LoginResult {IsAuhtentaced=false,Message="",Token=null };

            }
            return await _authenticationService.login(username,password);
        }
    }
}