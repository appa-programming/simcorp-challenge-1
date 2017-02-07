using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Helper;

namespace WordCounterSolver
{
    public class Solver
    {
        public List<string> SolveChallenge(string text)
        {
            // Get each word.
            string[] words = StringHelper.SplitWordsFromText(text);
            // Word count
            Dictionary<string, int> wordCount = StringHelper.GetWordCount(words);
            // Get List of lines to display to output device (in this case console)
            return StringHelper.GetLinesOfTextToDisplay(wordCount);
        }
    }
}
