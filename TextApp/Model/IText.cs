using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model.Enum;

namespace TextApp.Model
{
    interface IText
    {
        ISentence this[int index] { get; }
        IEnumerable<ISentence> GetSentencesInAscendingOrder();
        IEnumerable<IWord> GetWordsFromInterrogativeSentence(int length);
        void RemoveAllWordsStartingWhis(InitialSymbolType initialSymbol);
        void ReplaceWordWithSubString(int sentenceNumber, int wordNumber, string sunstituteLine);
    }
}
