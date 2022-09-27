using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while (line != null)
                    {
                        counter++;
                        int punctuation = CountPunctuation(line);
                        int letterrs = CountLetters(line);
                        line = $"Line {counter}: {line} ({letterrs})({punctuation})";
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static int CountPunctuation(string line)
        {
            int sum = 0;
            char[] arr = line.ToCharArray();
            foreach (char c in arr)
            {
                if (char.IsPunctuation(c))
                {
                    sum++;
                }
            }

            return sum;
        }

        private static int CountLetters(string line)
        {
            int sum = 0;
            char[] arr = line.ToCharArray();
            foreach (char c in arr)
            {
                if (char.IsLetter(c))
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
