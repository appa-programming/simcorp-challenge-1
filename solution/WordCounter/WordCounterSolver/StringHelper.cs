using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter.Helper
{
    public static class StringHelper
    {
        public static string[] SplitWordsFromText(string text)
        {
            string textWithNoMultipleSpaces = Regex.Replace(text, @"\s+", " ");
            string[] resp = textWithNoMultipleSpaces.Split(new char[3] { ' ', ',', '.' }).Where(s => s != "").ToArray();
            return resp;
        }

        public static Dictionary<string, int> GetWordCount(string[] words)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetLinesOfTextToDisplay(Dictionary<string, int> wordCount)
        {
            throw new NotImplementedException();
        }
    }
}
