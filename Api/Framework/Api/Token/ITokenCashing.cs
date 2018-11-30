using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api.Token
{
    public interface ITokenCashing
    {
        void CashToken(string tokenKey, ContextUser token);
        ContextUser GetToken(string tokenKey);
    }
}
