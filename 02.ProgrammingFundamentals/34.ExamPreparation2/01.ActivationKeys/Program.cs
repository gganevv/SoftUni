using System;

namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] inputArgs = input.Split(">>>");
                switch (inputArgs[0])
                {
                    case "Contains":
                        CheckSubstring(key, inputArgs[1]);
                        break;
                    case "Flip":
                        key = Flip(key, inputArgs[1], int.Parse(inputArgs[2]), int.Parse(inputArgs[3]));
                        break;
                    case "Slice":
                        key = Slice(key, int.Parse(inputArgs[1]), int.Parse(inputArgs[2]));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {key}");
        }

        static void CheckSubstring(string key, string substring)
        {
            if (key.Contains(substring))
            {
                Console.WriteLine($"{key} contains {substring}.");
            }
            else
            {
                Console.WriteLine($"Substring not found!");
            }
        }

        static string Flip(string key, string upperLower, int startIndex, int endIndex)
        {
            string result = string.Empty;
            result += key.Substring(0, startIndex);
            if (upperLower == "Upper")
            {
                result += key.Substring(startIndex, endIndex - startIndex).ToUpper();
            }
            else
            {
                result += key.Substring(startIndex, endIndex - startIndex).ToLower();
            }
            result += key.Substring(endIndex, key.Length - endIndex);
            Console.WriteLine(result);

            return result;
        }

        private static string Slice(string key, int startIndex, int endIndex)
        {
            string result = string.Empty;
            result += key.Substring(0, startIndex);
            result += key.Substring(endIndex, key.Length - endIndex);
            Console.WriteLine(result);

            return result;
        }
    }
}
