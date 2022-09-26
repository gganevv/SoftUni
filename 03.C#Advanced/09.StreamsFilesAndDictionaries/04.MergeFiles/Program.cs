using System;
using System.IO;
using System.Text;

namespace MergeFiles
{
    public class MergeFiles
    {
        public static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    StringBuilder sb = new StringBuilder();
                    string[] text1 = reader1.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                    string[] text2 = reader2.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                    int lastIndex = 0;
                    for (int i = 0; i < Math.Min(text1.Length, text2.Length); i++)
                    {
                        sb.AppendLine(text1[i]);
                        sb.AppendLine(text2[i]);
                        lastIndex = i;
                    }
                    if (text1.Length > text2.Length)
                    {
                        for (int i = lastIndex; i < text1.Length; i++)
                        {
                            sb.AppendLine(text1[i]);
                        }
                    }
                    else if (text2.Length > text1.Length)
                    {
                        for (int i = lastIndex + 1; i < text2.Length; i++)
                        {
                            sb.AppendLine(text2[i]);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        writer.WriteLine(sb.ToString());
                    }
                }
            }
        }
    }
}
