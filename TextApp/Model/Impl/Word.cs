using System;
using System.Linq;
using TextApp.Model.Enum;

namespace TextApp.Model.Impl
{
    class Word : IWord
    {
        public Word(string chars)
        {

            Chars = chars;
            Length = Chars?.Length ?? 0;
        }
        public int Length { get; }

        public int LineNumber { get; set; }

        public string Chars { get; }

        public InitialSymbolType InitialSymbol(string[] vowels)
        {
            return Char.IsDigit(Chars[0]) ? InitialSymbolType.Numeral : vowels.Contains(Chars[0].ToString().ToLower()) ? InitialSymbolType.Vowel : InitialSymbolType.Consonant;
        }
    }
}
