using System;
using System.Collections.Generic;

namespace Abstract.Entities
{
    public partial class SysPageActions
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int ActionId { get; set; }
        public bool IsAllowed { get; set; }
        public int? RoleId { get; set; }

        public SysActions Action { get; set; }
        public SysPages Page { get; set; }
        public Roles Role { get; set; }
    }
}
