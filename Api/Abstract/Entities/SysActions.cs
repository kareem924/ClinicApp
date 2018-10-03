using System;
using System.Collections.Generic;

namespace Abstract.Entities
{
    public partial class SysActions
    {
        public SysActions()
        {
            SysPageActions = new HashSet<SysPageActions>();
        }

        public int Id { get; set; }
        public string ActionName { get; set; }

        public ICollection<SysPageActions> SysPageActions { get; set; }
    }
}
