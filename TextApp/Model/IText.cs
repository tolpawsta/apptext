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
        IEnumerable<IWord> FindWordsFromSentence(int lengthWord, SentenceType sentenceType);
        void RemoveAllWordsStartingWhis(int lengthWord, InitialSymbolType initialSymbol);
        void ReplaceWordWithElements(int sentenceNumber, int lengthWord, List<ISentenceItem> elements);
        void ReplaceWordWithSubString(int sentenceNumber, int lengthWord, string subString, Func<string,ISentence> predicate);
    }
}
