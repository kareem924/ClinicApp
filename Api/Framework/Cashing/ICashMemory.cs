using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Cashing
{
    public interface ICashMemory
    {
        void CashToken(string cashKey, object objectToCash);
        object GetToken(string cashKey);
    }
}
