using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model.Impl
{
    class Punctuation : IPunctuation
    {
        
        public Punctuation(string chars)
        {
           Symbols = new Symbol(chars);
        }
        public Symbol Symbols { get; }

        public string Chars => Symbols.Chars;
    }
}
