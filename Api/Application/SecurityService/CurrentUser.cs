using Framework.Api;
using Framework.Cashing;
using Framework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SecurityService
{
    public class CurrentUser : ICurrentUser
    {
        readonly ICashMemory _tokenCashing;
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor, ICashMemory tokenCashing)
        {
            _tokenCashing = tokenCashing;
         
            _httpContextAccessor = httpContextAccessor;
        }
        public ContextUser GetCurrentUser
        {
            get
            {
                _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationValue);
                if (StringValues.IsNullOrEmpty(authorizationValue)) return null;

                ContextUser user = _tokenCashing.GetToken(authorizationValue) as ContextUser;
                if (user == null)
                {
                    user = null;
                    if (user == null) return null;
                    user.ExpiresOn = DateTime.UtcNow.AddDays(30).Ticks;
                    user.Authenticated = true;
                }
                return user;
            }
        }

       
    }
}
