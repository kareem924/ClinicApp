using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models.Result
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName {get;set;} 
        public string DisplayName { get; set; }
        public string[] Role { get; set; }

    }
}
