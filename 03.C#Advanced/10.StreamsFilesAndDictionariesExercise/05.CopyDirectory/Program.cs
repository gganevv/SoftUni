using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = $@"{Console.ReadLine()}";
            string outputPath = $@"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var files = Directory.GetFiles(inputPath);
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                File.Copy(file, outputPath + "\\" + fi.Name);
            }
        }
    }
}
