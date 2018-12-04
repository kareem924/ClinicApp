using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{
      [Table("SysPages")]
    public partial class SysPages
    {
        public SysPages()
        {
           
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public int ParentId { get; set; }

       
    }
}
