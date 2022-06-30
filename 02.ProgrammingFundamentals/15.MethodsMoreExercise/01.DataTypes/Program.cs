using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string value = Console.ReadLine();
            string result = string.Empty;
            switch (type)
            {
                case "int":
                    result = ProcessValue(int.Parse(value));
                    break;
                case "real":
                    result = ProcessValue(double.Parse(value));
                    break;
                case "string":
                    result = ProcessValue(value);
                    break;
                default:
                    break;
            }
            Console.WriteLine(result);
        }

        private static string ProcessValue(string s) => $"${s}$";

        private static string ProcessValue(double n) => $"{n * 1.5:f2}";

        private static string ProcessValue(int n) => $"{n * 2}";
    }
}
