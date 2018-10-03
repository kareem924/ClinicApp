using System;
using System.Collections.Generic;

namespace Abstract.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            SysPageActions = new HashSet<SysPageActions>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<SysPageActions> SysPageActions { get; set; }
    }
}
