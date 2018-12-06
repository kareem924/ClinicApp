using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Framework.Models
{
    public class ContextUser : ClaimsIdentity
    {
        public string Lang { get; set; }
        public string DisplayName { get; set; }
        public long ExpiresOn { get; set; }
        public bool Authenticated { get; set; }
        public IEnumerable<Claim> MyClaims { get; set; }
        public override IEnumerable<Claim> Claims => MyClaims;
        public override bool IsAuthenticated => Authenticated;
        public override string AuthenticationType => "Bearer";
    }                                               
}