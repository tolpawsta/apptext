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
        private string _chars;

        public Word(string chars)
        {

            _chars = chars;
            Length = _chars?.Length ?? 0;
        }
        public int Length { get; }

        public int LineNumber { get; set; }

        public string Chars => _chars;

        public InitialSymbolType InitialSymbol(string[] vowels)
        {
            return Char.IsDigit(_chars[0]) ? InitialSymbolType.Numeral : vowels.Contains(_chars[0].ToString().ToLower()) ? InitialSymbolType.Vowel : InitialSymbolType.Consonant;
        }
    }
}
