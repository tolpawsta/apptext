using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model.Enum;

namespace TextApp.Model
{
    class SentenceHelper
    {
       public static SentenceType GetSentenceType(ISentenceItem sentenceItem)
        {
            if (!(sentenceItem is IPunctuation))
            {
                throw new FormatException("Не удается установить тип");
            }
            IPunctuation punctuation = (IPunctuation)sentenceItem;
            if (punctuation.Chars.Equals("."))
            {
                return SentenceType.Declarative;
            }
            else if (punctuation.Chars.Contains("?"))
            {
                return SentenceType.Interrogative;
            }
            else return SentenceType.Exclamatory;
        }
    }
}
