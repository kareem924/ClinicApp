using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{
       [Table("UserClaims")]
    public partial class UserClaims
    {
        public int Id { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
