using System;
using System.Collections.Generic;

namespace Abstract.Entities
{
    public partial class SysPages
    {
        public SysPages()
        {
            InverseParent = new HashSet<SysPages>();
            SysPageActions = new HashSet<SysPageActions>();
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public int ParentId { get; set; }

        public SysPages Parent { get; set; }
        public ICollection<SysPages> InverseParent { get; set; }
        public ICollection<SysPageActions> SysPageActions { get; set; }
    }
}
