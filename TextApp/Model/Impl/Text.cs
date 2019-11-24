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
       



    }
}
