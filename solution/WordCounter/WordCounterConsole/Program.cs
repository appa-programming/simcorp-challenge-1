using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Helper;
using WordCounterSolver;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file as one string.
            string textFromFile = System.IO.File.ReadAllText(@"..\..\FilesToRead\Test1.txt");

            Solver solver = new Solver();
            List<string> textToDisplay = solver.SolveChallenge(textFromFile);

            foreach (var line in textToDisplay)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
