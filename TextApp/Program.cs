using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextApp.Model;
using TextApp.Parser;
using System.Collections.Specialized;

namespace TextApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var parser = new TextParser();
            var filePath = ConfigurationManager.AppSettings.Get("FilePath");
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException();
                StreamReader streamReader = new StreamReader(filePath,Encoding.Default);

                IText text = parser.Parse(streamReader);
                Console.WriteLine(text.ToString());
                Console.WriteLine("==========================================");
                text.GetWordsFromSentence(5, Model.Enum.SentenceType.Interrogative).ToList().ForEach(Console.WriteLine);
            }
            catch (FileNotFoundException fileException)
            {
                Console.WriteLine(fileException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
}
