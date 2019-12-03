using System;
using System.Linq;

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

        public string Chars => String.Join(String.Empty, Symbols.Select(s => s.Chars));
    }
}
