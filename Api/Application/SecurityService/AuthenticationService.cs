using Abstract.Repositry;
using Abstract.Service;
using Framework.Models.Result;
using Framework.Extensions;
using System.Threading.Tasks;
using Abstract.Entities;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Configuration;

namespace Application.SecurityService
{
    public class AuthenticationService 
    {
        // private readonly IUserRepositry _userRepositry;
        // private IConfiguration _configuration;
        // public AuthenticationService(IUserRepositry userRepositry, IConfiguration configuration)
        // {
        //     _userRepositry = userRepositry;
        //     _configuration = configuration;
        // }
        // public Task<bool> ActivateEmail(string code)
        // {

        //     throw new System.NotImplementedException();
        // }

        // public async Task<Users> Check(string name, string password)
        // {
        //     var user = await _userRepositry.CheckIsAuthorisedUserAsync(name, password);
        //     return user;
        // }

        // public Task<bool> ForgetPassword(string email)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public JwtResult GenerateToken(UserDto user)
        // {
        //     var objectSerialzed = JsonConvert.SerializeObject(user);
        //     return new JwtResult
        //     {
        //         Token = objectSerialzed.Encrypt(_configuration.GetSection("Encryption").GetSection("key").Value),
        //         ExpiredToken =DateTime.Now.AddHours(24),
        //     };
        // }
        
        // public async Task<LoginResult> login(string userName, string password)
        // {
        //     LoginResult rslt;
        //     var isAuthentactedUser = await Check(userName, password);
        //     if (isAuthentactedUser != null)
        //     {
        //        return  rslt = new LoginResult(){
        //              Token=GenerateToken(new UserDto{Id=isAuthentactedUser.Id,DisplayName=isAuthentactedUser.Name}),
        //              IsAuhtentaced=true,
        //              Message="Success"
        //          };
        //     }
        //     return rslt=new LoginResult{
        //         Token=null,
        //         IsAuhtentaced=false,
        //         Message="Failed Authentcate"
        //     };
            
        // }

        // public Task<bool> ResetPassword(string email, string oldPassword, string newPassword)
        // {
        //     throw new System.NotImplementedException();
        // }

        // Task<Users> IAuthenticationService.Check(string name, string password)
        // {
        //     throw new NotImplementedException();
        // }
    }
}