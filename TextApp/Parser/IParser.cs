using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model;
using TextApp.Model.Impl;

namespace TextApp.Parser
{
    interface IParser
    {
        Text Parse(StreamReader fileReader);
        IList<ISentenceItem> GetSentenceItems(string wordsKit);
        ISentence ParseSentence(string sentence);
    }
}
