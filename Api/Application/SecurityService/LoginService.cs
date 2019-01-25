using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abstract.Entities;
using Abstract.Repositry;
using Abstract.Service;
using Framework.Extensions;
using Framework.Models;
using Framework.Models.Result;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
                var token = GenerateToken(new UserDto { Id = authentacedUser.Id,UserName = authentacedUser.UserName });
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

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Encryption").GetSection("key").Value);
            
            var tokenDescriptor =  CreatetokenDescriptor(user, key).Result;
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var writeToken = tokenHandler.WriteToken(token);
            return new JwtResult
            {
                Token = writeToken,
                ExpiredToken = tokenDescriptor.Expires.GetValueOrDefault(),
            };
        }

        public async Task<SecurityTokenDescriptor> CreatetokenDescriptor(UserDto user, byte[] key)
        {
            var userClaims = await _userClaimsRepositry.GetUserClaims(user.Id);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                })
            };
            if (userClaims.Any())
            {
                foreach (var claim in userClaims)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(claim.ClaimName, claim.ClaimValue));
                }
            }
           
            tokenDescriptor.Expires = DateTime.Now.AddHours(24);
            tokenDescriptor.SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            return tokenDescriptor;
        }
    }
}






