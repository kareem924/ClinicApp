using Framework.Api.Token;
using Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Framework.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly bool _isActive = true;
        private ICurrentUser _currentUser;
        private ITokenCashing _TokenCashing;


        public AuthFilter()
        {

        }
        public AuthFilter(bool isActive)
        {
            _isActive = isActive;

        }

        private static bool SkipAuthorization(AuthorizationFilterContext actionContext)
        {
            Contract.Assert(actionContext != null);
            return actionContext != null && actionContext.ActionDescriptor.FilterDescriptors.Any(filterDescriptors => filterDescriptors.Filter.GetType() == typeof(AllowAnonymousFilter));
        }

        protected virtual ContextUser FetchAuthHeader(AuthorizationFilterContext filterContext)
        {
            filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationValue);
            var credentials = _currentUser.GetCurrentUser;
            if (credentials != null)
            {
                _TokenCashing.CashToken(authorizationValue, credentials);
            }
            return credentials;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _currentUser = null;
            _TokenCashing = context.HttpContext.RequestServices.GetService(typeof(ITokenCashing)) as ITokenCashing;
            if (SkipAuthorization(context)) return;
            if (!_isActive) return;

            var identity = FetchAuthHeader(context);
            if (identity == null)
            {
                ChallengeAuthRequest(context);
            }
            else
            {

                context.HttpContext.User.AddIdentity(identity);

            }
        }

        protected virtual bool OnAuthorizeUser(string user, AuthorizationFilterContext filterContext)
        {
            if (string.IsNullOrEmpty(user))
                return false;
            return true;
        }

        private static void ChallengeAuthRequest(AuthorizationFilterContext filterContext)
        {
            var dnsHost = filterContext.HttpContext.Request.Host.Value;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            filterContext.HttpContext.Response.Headers.Add("WWW-Authenticate", string.Format("user_auth realm=\"{0}\"", dnsHost));
            filterContext.Result = new UnauthorizedResult() { };
        }

    }
}
