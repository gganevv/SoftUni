namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder stringBuilder = new StringBuilder();
                char[] separators = new char[] { '-', ',', '.', '!', '?' };
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    counter++;
                    if (counter % 2 != 0)
                    {
                        line = string.Join(" ", line.Split().Reverse().ToArray());
                        string[] temp = line.Split(separators, StringSplitOptions.None);
                        stringBuilder.AppendLine(String.Join("@", temp));
                    }

                    line = reader.ReadLine();
                }

                return stringBuilder.ToString();
            }
        }
    }
}
