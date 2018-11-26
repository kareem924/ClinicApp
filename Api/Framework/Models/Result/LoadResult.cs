using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models.Result
{
    public class LoadResult
    {
        public int TotalCount { get; set; }
        public IEnumerable List { get; set; }
    }
}
