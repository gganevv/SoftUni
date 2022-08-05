using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodesCount = int.Parse(Console.ReadLine());
            string barcodePattern = @"(@#+)([A-Z][A-Za-z\d]{4,}[A-Z])(@#+)";
            string digitsPattern = @"\d";
            for (int i = 0; i < barcodesCount; i++)
            {
                string barcode = Console.ReadLine();
                Match match = Regex.Match(barcode, barcodePattern);
                if (match.Success)
                {
                    Console.Write("Product group: ");
                    var digits = Regex.Matches(barcode, digitsPattern);
                    if (digits.Count > 0)
                    {
                        Console.WriteLine(String.Join("", digits));
                    }
                    else
                    {
                        Console.WriteLine("00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
