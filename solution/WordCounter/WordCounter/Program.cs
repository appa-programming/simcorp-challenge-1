using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Helper;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file as one string.
            string textFromFile = System.IO.File.ReadAllText(@"..\..\FilesToRead\Test1.txt");
            // Get each word.
            string[] words = StringHelper.SplitWordsFromText(textFromFile);
            // Word count
            Dictionary<string, int> wordCount = StringHelper.GetWordCount(words);
            // 
            List<string> textToDisplay = StringHelper.GetLinesOfTextToDisplay(wordCount);

            foreach (var line in textToDisplay)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
