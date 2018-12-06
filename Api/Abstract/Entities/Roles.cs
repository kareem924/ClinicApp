using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{
    [Table("Roles")]

    public partial class Roles
    {
        public Roles()
        {

        }

        public int Id { get; set; }
        public string RoleName { get; set; }


    }
}
