using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Helpers;
using TextApp.Model.Enum;

namespace TextApp.Model.Impl
{
    class Sentence : ISentence
    {
        private int _index;
        public Sentence()
        {
            SentenceItems = new List<ISentenceItem>();
        }
        public Sentence(IEnumerable<ISentenceItem> sentenceItems) : this()
        {
            foreach (var item in sentenceItems)
            {
                SentenceItems.Add(item);
            }
        }

        public IList<ISentenceItem> SentenceItems { get; }

        public SentenceType SentenceType
        {
            get
            {
                return SentenceHelper.GetSentenceType(SentenceItems.Last());
            }
        }

        public IEnumerable<IWord> GetWordsWithoutRepetition(int length)
        {
            return SentenceItems.Where(s => s is IWord).Cast<IWord>().Where(s => s.Length == length);
        }

        public ISentence RemoveWordsBy(Func<IWord, bool> predicate)
        {
            return new Sentence(SentenceItems.Where(s => !(s is IWord && predicate((IWord)s))));
        }

        public IEnumerable<ISentenceItem> ReplaceWordByElements(Func<IWord, bool> predicate, IList<ISentenceItem> elements)
        {
            var resultSentence = new List<ISentenceItem>();
            foreach (var item in SentenceItems)
            {
                if ((item is IWord) && predicate((item as IWord)))
                {
                    resultSentence.AddRange(elements);
                    continue;
                }
                resultSentence.Add(item);
            }
            return resultSentence;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(" ");
            CombineSentenceItems(-1, sb);
            return sb.ToString();

        }

        private void CombineSentenceItems(int index, StringBuilder sb)
        {
            _index = index;
            while (true)
            {
                _index++;
                if (_index >= SentenceItems.Count) break;
                sb.Append(SentenceItems[_index].Chars);
                var nextElement = SentenceItems.ElementAtOrDefault(_index + 1);
                if (nextElement == null) continue;
                if (PunctuationHelper.EndSymsols.Contains(SentenceItems[_index].Chars) ||
                    PunctuationHelper.OperationSymbols.Contains(SentenceItems[_index].Chars) ||
                    PunctuationHelper.CloseSymbols.Contains(nextElement.Chars) ||
                    PunctuationHelper.InnerSymbols.Contains(nextElement.Chars) ||
                    PunctuationHelper.EndSymsols.Contains(nextElement.Chars) ||
                    PunctuationHelper.EndSymsols.Contains(nextElement.Chars) ) continue;
                if (PunctuationHelper.CloseSymbols.Contains(SentenceItems[_index].Chars))
                {
                    break;
                }
                if (PunctuationHelper.OpenSymbols.Contains(SentenceItems[_index].Chars) ||
                    PunctuationHelper.RepeatSymbols.Contains(SentenceItems[_index].Chars))
                {
                    CombineSentenceItems(_index, sb);
                }

                if (!PunctuationHelper.CloseSymbols.Contains(nextElement.Chars) ||
                    PunctuationHelper.OpenSymbols.Contains(nextElement.Chars))
                {
                    sb.Append(" ");
                }
            }
        }
    }
}
