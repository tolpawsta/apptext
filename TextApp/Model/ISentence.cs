using System.Collections.Generic;
using TextApp.Model.Enum;

namespace TextApp.Model
{
    interface ISentence
    { 
        IList<ISentenceItem> SentenceItems { get; }
        SentenceType SentenceType { get; }
        IEnumerable<IWord> GetWordsWithoutRepetition(int length);

    }
}