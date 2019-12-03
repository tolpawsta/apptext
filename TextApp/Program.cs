using System;
using System.Configuration;
using System.IO;
using System.Text;
using TextApp.Model;
using TextApp.Model.Enum;
using TextApp.Parser;
using TextApp.View;

namespace TextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new TextParser();
            var view = new ConsoleView();
            var lineSeparator = "============================================";
            var filePath = ConfigurationManager.AppSettings.Get("FilePath");
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException();
                StreamReader streamReader = new StreamReader(filePath, Encoding.Default);
                IText text = parser.Parse(streamReader);
                view.Show("All parsed text:");
                view.Show(lineSeparator);
                view.Show(text.ToString());

                view.Show(lineSeparator);
                view.Show("All text sentences ordered by count words");
                view.Show(lineSeparator);
                view.Show(text.GetSentencesInAscendingOrder());
                view.Show(lineSeparator);

                view.Show("Find and print all words without repetition in concrete type sentence:");
                view.Show(lineSeparator);
                view.Show(text.FindWordsFromSentence(6, SentenceType.Interrogative));
                view.Show(lineSeparator);

                view.Show("Remove from text all words with concrete length and starting with initial type symbol");
                view.Show(lineSeparator);
                text.RemoveAllWordsStartingWhis(4, InitialSymbolType.Consonant);
                view.Show(text.ToString());
                view.Show(lineSeparator);

                view.Show("In another sentence all words with conrete length replace by elements");
                view.Show(lineSeparator);
                text.ReplaceWordWithSubString(3, 4, "another, sentence kit", parser.ParseSentence);
                view.Show(text.ToString());
                view.Show(lineSeparator);
            }
            catch (FileNotFoundException fileException)
            {
                view.Show(fileException.Message);
            }
            catch (Exception exception)
            {
                view.Show(exception.Message);
            }
            view.Stop();
        }
    }
}
