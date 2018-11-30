using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Extensions;
using Framework.Models.Result;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.SecurityService
{
    public class LoginService : ILoginService
    {
          private IConfiguration _configuration;
           private readonly IloginRepositry _loginRepositroy;
        public LoginService(IloginRepositry loginRepositroy, IConfiguration configuration)
        {
            _configuration=configuration;
            _loginRepositroy=loginRepositroy;
        }

        public Task<LoginResult> login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Users> Check(string name, string password)
        {
            return await _loginRepositroy.CheckIsAuthorisedUserAsync(name, password);
       
        }

        public JwtResult GenerateToken(UserDto user)
        {
           var objectSerialzed = JsonConvert.SerializeObject(user);
            return new JwtResult
            {
                Token = objectSerialzed.Encrypt(_configuration.GetSection("Encryption").GetSection("key").Value),
                ExpiredToken =DateTime.Now.AddHours(24),
            };
        }
    }
}






