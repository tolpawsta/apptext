using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model.Impl
{
    class Digit : IDigit
    {
        public Symbol this[int index] => throw new NotImplementedException();

        public Symbol[] Simbols => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public string Chars => throw new NotImplementedException();
    }
}
