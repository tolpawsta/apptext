using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model.Impl
{
    class Text:IText
    {
        public IList<ISentence> Sentences { get; set; }

        public ISentence this[int index] => Sentences[index];

        public Text()
        {
            Sentences = new List<ISentence>();
        }

        public Text(IEnumerable<ISentence> sentences):this()
        {
            foreach (var sentence in sentences)
            {
                Sentences.Add(sentence);
            }
        }

        public IEnumerable<ISentence> GetSentencesInAscendingOrder()
        {
            return Sentences.OrderBy(s=>s.SentenceItems.Where(x=>x is IWord).Count());

        }

        public IEnumerable<IWord> GetWordsFromInterrogativeSentence(int length)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllWordsStartingWhisConsonant()
        {
            throw new NotImplementedException();
        }

        public void ReplaceWordWithSubString(int sentenceNumber, int wordNumber, string sunstituteLine)
        {
            throw new NotImplementedException();
        }
    }
}
