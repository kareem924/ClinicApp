using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{
    [Table("SysPageActions")]
    public partial class SysPageActions
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int ActionId { get; set; }
        public bool IsAllowed { get; set; }
        public int? RoleId { get; set; }

       
    }
}
