using System.Collections.Generic;

namespace TextApp.Model
{
    interface ISentence
    { 
        IEnumerable<ISentenceItem> SentenceItems { get; }
        bool IsInterrogative { get; }
    }
}