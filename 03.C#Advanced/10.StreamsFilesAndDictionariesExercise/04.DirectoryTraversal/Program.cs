using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);
            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string path)
        {
            Dictionary<string, Dictionary<string, double>> filesList = new Dictionary<string, Dictionary<string, double>>();
            var files = Directory.GetFiles(path);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                string extension = fi.Extension;
                string fileName = fi.Name;
                double size = fi.Length / 1024;
                if (!filesList.ContainsKey(extension))
                {
                    filesList.Add(extension, new Dictionary<string, double>());
                }
                filesList[extension].Add(fileName, size);
            }

            filesList = filesList.OrderByDescending(x => x.Value.Values.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var extensionGroup in filesList)
            {
                stringBuilder.AppendLine(extensionGroup.Key);
                foreach (var file in extensionGroup.Value.OrderByDescending(x => x.Value))
                {
                    stringBuilder.AppendLine($"--{file.Key} - {file.Value}kb");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string reportContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(reportContent);
            }
        }
    }
}
