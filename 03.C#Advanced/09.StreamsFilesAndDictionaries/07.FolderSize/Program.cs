using System;
using System.IO;
using System.Linq;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputPath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            double size = DirSize(directory) / 1024.0;

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(size);
            }
        }

        public static long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) +
                   dir.GetDirectories().Sum(di => DirSize(di));
        }
    }
}
