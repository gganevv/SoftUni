using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputPath, string outputPath)
        {
            StreamReader reader = new StreamReader(inputPath);
            StreamWriter writer = new StreamWriter(outputPath);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while (line != null)
                    {
                        counter++;
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
