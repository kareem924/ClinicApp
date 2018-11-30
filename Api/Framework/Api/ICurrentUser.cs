using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Api
{
   public interface ICurrentUser
    {
        ContextUser GetCurrentUser { get; }
    }
}
