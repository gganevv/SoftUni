using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOnePath, string partTwoPath)
        {
            using (FileStream source = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream part1 = new FileStream(partOnePath, FileMode.Create))
                {
                    int odd = source.Length % 2 == 1 ? 1 : 0;
                    byte[] buffer = new byte[source.Length / 2 + odd];
                    source.Read(buffer);
                    part1.Write(buffer);
                }
                using (FileStream part2 = new FileStream(partTwoPath, FileMode.Create))
                {
                    byte[] buffer = new byte[source.Length / 2];
                    source.Read(buffer);
                    part2.Write(buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joined = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream part = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[part.Length];
                    part.Read(buffer);
                    joined.Write(buffer);
                }
                using (FileStream part = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[part.Length];
                    part.Read(buffer);
                    joined.Write(buffer);
                }
            }
        }
    }
}
