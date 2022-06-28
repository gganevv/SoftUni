using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstNum, secondNum));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString));
                    break;
                default:
                    break;
            }
        }

        private static string GetMax(string firstString, string secondString)
        {
            int result = firstString.CompareTo(secondString);
            return result > 0 ? firstString : secondString;
        }

        private static int GetMax(int firstNum, int secondNum) => firstNum > secondNum ? firstNum : secondNum;

        private static char GetMax(char firstChar, char secondChar) => firstChar > secondChar ? firstChar : secondChar;
    }
}