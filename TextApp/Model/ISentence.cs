using System;
using System.Collections.Generic;
using TextApp.Model.Enum;

namespace TextApp.Model
{
    interface ISentence
    {
        IList<ISentenceItem> SentenceItems { get; }
        SentenceType SentenceType { get; }
        IEnumerable<IWord> GetWordsWithoutRepetition(int length);
        ISentence RemoveWordsBy(Func<IWord, bool> predicate);
        IEnumerable<ISentenceItem> ReplaceWordByElements(Func<IWord, bool> predicate, IList<ISentenceItem> elements);


    }
}