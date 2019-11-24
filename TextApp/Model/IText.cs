using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model
{
    interface IText
    {
        ISentence this[int index] { get; }
        IEnumerable<ISentence> GetSentencesInInAscendingOrder();
        IEnumerable<IWord> GetWordsFromInterrogativeSentence(int length);
        void RemoveAllWordsStartingWhisConsonant();
    }
}
