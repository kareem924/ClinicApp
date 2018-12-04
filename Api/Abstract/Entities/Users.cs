using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{
      [Table("Users")]
    public partial class Users
    {
        public Users()
        {
           
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
        public string PasswordHash { get; set; }

    }
}
