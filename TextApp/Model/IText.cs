using System;
using System.Collections.Generic;
using TextApp.Model.Enum;

namespace TextApp.Model
{
    interface IText
    {
        ISentence this[int index] { get; }
        IEnumerable<ISentence> GetSentencesInAscendingOrder();
        IEnumerable<IWord> FindWordsFromSentence(int lengthWord, SentenceType sentenceType);
        void RemoveAllWordsStartingWhis(int lengthWord, InitialSymbolType initialSymbol);
        void ReplaceWordWithSubString(int sentenceNumber, int lengthWord, string subString, Func<string,ISentence> predicate);
    }
}
