using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model.Impl
{
    class Word : IWord
    {
        public Symbol[] this[int index] => throw new NotImplementedException();

        public Symbol[] Symbols => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public int LineNumber => throw new NotImplementedException();

        public bool IsConsonant => throw new NotImplementedException();

        public string Chars => throw new NotImplementedException();
    }
}
