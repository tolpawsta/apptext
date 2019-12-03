using System.Collections.Generic;
using System.IO;
using TextApp.Model;
using TextApp.Model.Impl;

namespace TextApp.Parser
{
    interface IParser
    {
        Text Parse(StreamReader fileReader);
        ISentence ParseSentence(string sentence);
    }
}
