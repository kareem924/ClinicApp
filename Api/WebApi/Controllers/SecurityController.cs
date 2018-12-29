using System.Threading.Tasks;
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
        public async Task<ActionResult<LoginResult>> Login([FromBody]LoginModel model)
        {
            _logger.LogInformation(LoggingEvents.Loging, "Logging in", model.UserName);
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Bad Request");
                var badresult = new LoginResult { IsAuhtentaced = false, Message = "", Token = null };
                return BadRequest(badresult);
            }
            var result = await _loginService.Login(model);
            return Ok(result);
        }

    }
}