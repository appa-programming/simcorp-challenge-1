using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file as one string.
            string textFromFile = System.IO.File.ReadAllText(@"..\..\FilesToRead\Test1.txt");



            Console.WriteLine(textFromFile);
            Console.ReadLine();
        }
    }
}
