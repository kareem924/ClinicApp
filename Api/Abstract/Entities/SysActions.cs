using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstract.Entities
{  [Table("SysActions")]
    public partial class SysActions
    {
      
        public SysActions()
        {
            
        }

        public int Id { get; set; }
        public string ActionName { get; set; }

       
    }
}
