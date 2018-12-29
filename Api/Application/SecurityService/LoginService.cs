using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Extensions;
using Framework.Models;
using Framework.Models.Result;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.SecurityService
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepositry _loginRepositroy;
        private readonly IUserClaimsRepositry _userClaimsRepositry;
        private readonly IUserTokenRepositry _userTokenRepositry;
        public LoginService(ILoginRepositry loginRepositroy, IConfiguration configuration, IUserClaimsRepositry userClaimsRepositry, IUserTokenRepositry userTokenRepositry)
        {
            _configuration = configuration;
            _loginRepositroy = loginRepositroy;
            _userTokenRepositry = userTokenRepositry;
            _userClaimsRepositry = userClaimsRepositry;
        }

        public async Task<LoginResult> Login(LoginModel model)
        {
            var authentacedUser = await Check(model.UserName, model.Password);
            if (authentacedUser != null)
            {
                var token = GenerateToken(new UserDto { Id = authentacedUser.Id, Guid = Guid.NewGuid().ToString() });
                await UpdateUserTokenInDb(authentacedUser.Id, model.LoginProvider, token.Token);
                return new LoginResult() { Token = token, IsAuhtentaced = true, Message = "success" };

            }
            return new LoginResult()
            {
                IsAuhtentaced = false,
                Message = "not authorised user",
                Token = null
            };
        }
        public async Task UpdateUserTokenInDb(int userId, string providerName, string token)
        {
            var userToken = await _userTokenRepositry.GetUserTokensWithProviderName(userId, providerName);
            if (userToken != null)
            {
                userToken.Token = token;
                await _userTokenRepositry.UpdateAsync(userToken);
            }
            else
            {
                await _userTokenRepositry.InsertAsync(new UserTokens
                { LoginProvider = providerName, Token = token, UserId = userId });
            }

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
                ExpiredToken = DateTime.Now.AddHours(24),
            };
        }

        public async Task<ContextUser> GetUserContext(Users user)
        {
            var userClaims = await _userClaimsRepositry.GetUserClaims(user.Id);
            var contextUser = new ContextUser
            {
                DisplayName = user.Name,
                Lang = "Ar",
                MyClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                }
            };
            foreach (var item in userClaims)
            {
                contextUser.MyClaims.Add(new Claim(item.ClaimName, item.ClaimValue));

            }
            contextUser.Authenticated = true;

            return contextUser;
        }
    }
}






