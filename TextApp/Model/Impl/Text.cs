using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model.Enum;

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
            return Sentences.OrderBy(s=>s.SentenceItems.OfType<IWord>().Count());

        }

        public IEnumerable<IWord> GetWordsFromSentence(int lengthWord,SentenceType sentenceType)
        {
            var result = new List<IWord>();
            var sentences = Sentences.Where(s => s.SentenceType == sentenceType).ToList();
            foreach (var sentence in sentences)
            {
                result.AddRange(sentence.GetWordsWithoutRepetition(lengthWord));
            }
            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.First()).ToList();
        }

        public void RemoveAllWordsStartingWhis(InitialSymbolType initialSymbol)
        {
            throw new NotImplementedException();
        }

        public void ReplaceWordWithSubString(int sentenceNumber, int wordNumber, string sunstituteLine)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var sentence in Sentences)
            {
                sb.Append(sentence.ToString());
            }
            return sb.ToString();
        }
    }
}
