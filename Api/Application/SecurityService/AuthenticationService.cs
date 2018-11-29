using Abstract.Repositry;
using Abstract.Service;
using Framework.Models.Result;
using Framework.Extensions;
using System.Threading.Tasks;
using Abstract.Entities;
using Newtonsoft.Json;
using System;

namespace Application.SecurityService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepositry _userRepositry;
        public AuthenticationService(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }
        public Task<bool> ActivateEmail(string code)
        {

            throw new System.NotImplementedException();
        }

        public async Task<Users> Check(string name, string password)
        {
            var user = await _userRepositry.CheckIsAuthorisedUserAsync(name, password);
            return user;
        }

        public Task<bool> ForgetPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        public JwtResult GenerateToken(UserDto user)
        {
            var objectSerialzed = JsonConvert.SerializeObject(user);
            return new JwtResult
            {
                Token = objectSerialzed.Encrypt("h12sdfq4go8743f"),
                ExpiredToken=DateTime.Now.AddHours(24),

            };
        }
        
        public async Task<LoginResult> login(string userName, string password)
        {
            LoginResult rslt;
            var isAuthentactedUser = await Check(userName, password);
            if (isAuthentactedUser != null)
            {
               return  rslt = new LoginResult(){
                     Token=GenerateToken(new UserDto{Id=isAuthentactedUser.Id,DisplayName=isAuthentactedUser.Name}),
                     IsAuhtentaced=true,
                     Message="Success"
                 };
            }
            return rslt=new LoginResult{
                Token=null,
                IsAuhtentaced=false,
                Message="Failed Authentcate"
            };
            
        }

        public Task<bool> ResetPassword(string email, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }


    }
}