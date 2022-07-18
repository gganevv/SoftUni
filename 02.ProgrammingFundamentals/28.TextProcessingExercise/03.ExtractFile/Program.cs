using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine().Split('\\');
            string[] file = parts[parts.Length - 1].Split('.');
            string fileName = file[0];
            string extension = file[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}