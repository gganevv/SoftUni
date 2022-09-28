using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFile, string zipArchiveFile)
        {
            using (var archive = ZipFile.Open(zipArchiveFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(inputFile, Path.GetFileName(inputFile));
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFile, string fileNameOnly, string extractedFile)
        {
            using (var archive = ZipFile.Open(zipArchiveFile, ZipArchiveMode.Read))
            {
                archive.GetEntry(fileNameOnly).ExtractToFile(extractedFile);
            }
        }
    }
}
