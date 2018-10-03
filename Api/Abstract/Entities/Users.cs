using System;
using System.Collections.Generic;
namespace Abstract.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserClaims = new HashSet<UserClaims>();
            UserTokens = new HashSet<UserTokens>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string UserName { get; set; }
        public int? AccessFailedCoudnt { get; set; }
        public string EmailConfirmationCode { get; set; }
        public bool? IsActive { get; set; }
        public string EmailNormalized { get; set; }
        public string UsernameNormalized { get; set; }
        public int UserTypeId { get; set; }

        public ICollection<UserClaims> UserClaims { get; set; }
        public ICollection<UserTokens> UserTokens { get; set; }
    }
}
