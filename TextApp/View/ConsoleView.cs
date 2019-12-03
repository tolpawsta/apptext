using System;
using System.Collections.Generic;
using System.Linq;
using TextApp.Model;

namespace TextApp.View
{
    class ConsoleView : IView
    {
        public void Show(string message)
        {
            Console.WriteLine(message);
        }

        public void Show(IEnumerable<ISentenceItem> sentenceItems)
        {
            sentenceItems.ToList().ForEach(Console.WriteLine);
        }

        public void Show(IEnumerable<ISentence> sentences)
        {
            sentences.ToList().ForEach(s => Console.WriteLine(s.ToString()));
        }
        public void Show(ISentenceItem sentenceItem)
        {
            Console.WriteLine(sentenceItem.Chars);
        }

        public void Show(IEnumerable<IWord> words)
        {
            words.ToList().ForEach(w => Console.WriteLine(w.Chars));
        }

        public string Stop()
        {
            return Console.ReadLine();
        }
    }
}
