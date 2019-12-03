using System.Collections.Generic;
using TextApp.Model;

namespace TextApp.View
{
    interface IView
    {
        void Show(string message);
        void Show(IEnumerable<ISentence> sentences);
        void Show(IEnumerable<ISentenceItem> sentenceItems);
        void Show(ISentenceItem sentenceItem);
        string Stop();
        void Show(IEnumerable<IWord> words);
    }
}
