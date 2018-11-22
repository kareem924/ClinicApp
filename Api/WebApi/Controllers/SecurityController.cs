using System;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Models.Result;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public SecurityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
         [HttpGet]
        public async Task<LoginResult> Login(string username,string password )
        {
            return await _authenticationService.login(username,password);
        }
    }
}