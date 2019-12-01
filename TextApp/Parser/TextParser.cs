using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextApp.Helpers;
using TextApp.Model;
using TextApp.Model.Impl;

namespace TextApp.Parser
{
    class TextParser : IParser
    {
        private Regex _lineToSentenceRegex = new Regex(
            @"(?<=[\.*!\?])\s+(?=[А-Я]|[A-Z])|(?=\W&([А-Я]|[A-Z]))",
            RegexOptions.Compiled);

        private readonly Regex _sentenceToWordsRegex =
            new Regex(
                @"(\W*)(\w+[\-|`]\w+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(\W*)(\w+|\d+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\r\n|\W)|(.*)",
                RegexOptions.Compiled);
        private readonly Regex _removeWhiteSpaceBeforePunctRegex = new Regex(@"(\s+(?=[,;!?\)\>\}\]]))", RegexOptions.Compiled);
        private readonly Regex _removeWhiteSpaceAfterPunctRegex = new Regex(@"((?<=[(<{[])\s+)", RegexOptions.Compiled);
        private readonly Regex _removeMultiWhiteSpaceRegex = new Regex(@"\s+", RegexOptions.Compiled);
        private Regex _removeDuplicatePunctuationRegex;
        public IList<ISentenceItem> GetSentenceItems(string wordsKit)
        {
            throw new NotImplementedException();
        }

        public Text Parse(StreamReader fileReader)
        {

            var resultText = new Text();
            try
            {
                string line;
                string buffer = null;
                while ((line = fileReader.ReadLine()) != null)
                {
                    if (Regex.Replace(line, @"\s+", " ") != "")
                    {
                        line = ProcessedSentence(line);
                        line = buffer+line;
                        var sentences = _lineToSentenceRegex.Split(line)
                            .Select(x => Regex.Replace(x, @"\s+", @" "))
                            .ToArray();

                        if (!PunctuationHelper.EndSymsols.Contains(sentences.Last().Last().ToString()))
                        {
                            buffer = sentences.Last();
                            resultText.Sentences.AddRange(sentences
                                .Select(x => x)
                                .Where(x => x != sentences.Last())
                                .Select(ParseSentence));
                        }
                        else
                        {
                            resultText.Sentences.AddRange(sentences.Select(ParseSentence));
                            buffer = null;
                        }
                    }

                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Data.ToString());
            }
            finally
            {
                fileReader.Close();
            }
            return resultText;
        }

        public ISentence ParseSentence(string sentence)
        {
            var result = new Sentence();
            Func<string, int, ISentenceItem> toISentenceItem =
                (item, index) =>
                    (!PunctuationHelper.AllSymbols.Contains(item) &&
                     !NumberHelper.ArabicDigits.Contains(item[0].ToString()))
                        ? (ISentenceItem)new Word(item) { LineNumber = index }
                        : (NumberHelper.ArabicDigits.Contains(item[0].ToString()))
                            ? (ISentenceItem)new Number(item)
                            : new Punctuation(item);

            foreach (Match match in _sentenceToWordsRegex.Matches(sentence))
            {
                for (var i = 1; i < match.Groups.Count; i++)
                {
                    if (match.Groups[i].Value.Trim() != "")
                    {
                        result.SentenceItems.Add(toISentenceItem(match.Groups[i].Value.Trim(), i));
                    }
                }
            }

            return result;
        }

        public IList<ISentenceItem> SentenceItems(string wordsKit)
        {
            throw new NotImplementedException();
        }
        private string ProcessedSentence(string processingSentence)
        {
            processingSentence = _removeWhiteSpaceBeforePunctRegex.Replace(processingSentence, "");
            processingSentence = _removeWhiteSpaceAfterPunctRegex.Replace(processingSentence, "");
            processingSentence = _removeMultiWhiteSpaceRegex.Replace(processingSentence, " ");
            foreach (var item in PunctuationHelper.InnerSymbols)
            {
                processingSentence = Regex.Replace(processingSentence, @"[" + item + "]+", item);
            }
            return processingSentence;
        }
    }
}
