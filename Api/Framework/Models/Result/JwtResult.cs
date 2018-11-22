using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models.Result
{
  public  class JwtResult
    {
        public string Token { get; set; }
        public DateTime ExpiredToken { get; set; }

    }
}
