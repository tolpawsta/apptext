using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model.Enum;

namespace TextApp.Model.Impl
{
    class Sentence:ISentence
    {
        public Sentence(IEnumerable<ISentenceItem> sentenceItems)
        {
            SentenceItems = sentenceItems?.ToList();
        }

        public IList<ISentenceItem> SentenceItems { get; }

        public SentenceType sentenceType {
            get
            {
                return SentenceHelper.GetSentenceType(SentenceItems.Last());
            }
        }
    }
}
