using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextApp.Model;
using TextApp.Model.Impl;

namespace TextApp.Parser
{
    class TextParser : IParser
    {
        private Regex _lineToSentence = new Regex(
            @"(?<=[\.*!\?])\s+(?=[А-Я]|[A-Z])|(?=\W&([А-Я]|[A-Z]))",
            RegexOptions.Compiled);

        private readonly Regex _sentenceToWordsRegex =
            new Regex(
                @"(\W*)(\w+[\-|`]\w+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(\W*)(\w+|\d+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(.*)",
                RegexOptions.Compiled);
        public IList<ISentenceItem> GetSentenceItems(string wordsKit)
        {
            throw new NotImplementedException();
        }

        public Text Parse(StreamReader fileReader)
        {

            var resultText = new Text();
            while (true)
            {
                string line = null;
                string buffer = null;
                while ((line=fileReader.ReadLine())!=null)
                {
                   if(Regex.Replace(line,@"\s+"," ") != "")
                    {

                    }
                }
            }

        }

        public ISentence ParseSentence(string sentence)
        {
            throw new NotImplementedException();
        }

        public IList<ISentenceItem> SentenceItems(string wordsKit)
        {
            throw new NotImplementedException();
        }
    }
}
