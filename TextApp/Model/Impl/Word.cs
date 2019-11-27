using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model.Enum;

namespace TextApp.Model.Impl
{
    class Word : IWord
    {
        private int _lineNumber;
       
        public Word(int lineNumber, string chars)
        {
            _lineNumber = lineNumber;
            Symbols = chars?.Select(c => new Symbol(c)).ToArray();
            Length = Symbols?.Length ?? 0;
        }
        public Symbol this[int index] => Symbols[index];

        

        public Symbol[] Symbols { get; }

        public int Length { get; }

        public int LineNumber => _lineNumber;

        public string Chars
        {
            get
            {
                var sb = new StringBuilder();
                return sb.Append(Symbols.Select(x => x.Chars)).ToString();
            }

        }

        InitialSymbolType IWord.InitialSymbol => throw new NotImplementedException();

        public InitialSymbolType InitialSymbol(string[] vowels)
        {
            return Char.IsDigit(Symbols[0].Chars[0]) ? InitialSymbolType.Numeral : vowels.Contains(Symbols[0].Chars) ? InitialSymbolType.Vowel : InitialSymbolType.Consonant;
        }
    }
}
