﻿using System;
using System.Collections.Generic;

namespace Abstract.Entities
{
    public partial class UserTokens
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
