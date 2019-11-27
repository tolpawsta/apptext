using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model.Impl
{
    class Number : INumber
    {
        public Number(string chars)
        {
            Symbols = chars?.Select(x => new Symbol(x)).ToArray();
            Length = Symbols.Length;
        }
        public Symbol this[int index] => Symbols[index];

        public Symbol[] Symbols { get; }

        public int Length { get; }

        public string Chars => new StringBuilder().Append(Symbols.Select(s => s.Chars)).ToString();
    }
}
