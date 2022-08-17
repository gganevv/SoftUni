using System;

namespace _01.StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                switch (command)
                {
                    case "Change":
                        word = Change(inputArgs[1], inputArgs[2], word);
                        break;
                    case "Includes":
                        CheckIncludes(inputArgs[1], word);
                        break;
                    case "End":
                        CheckEnd(inputArgs[1], word);
                        break;
                    case "Uppercase":
                        word = MakeUppercase(word);
                        break;
                    case "FindIndex":
                        FindIndex(inputArgs[1], word);
                        break;
                    case "Cut":
                        word = Cut(int.Parse(inputArgs[1]), int.Parse(inputArgs[2]), word);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static string Change(string ch, string replacement, string word)
        {
            word = word.Replace(ch, replacement);
            Console.WriteLine(word);
            return word;
        }

        private static void CheckIncludes(string substring, string word)
        {
            string result = word.Contains(substring) ? "True" : "False";
            Console.WriteLine(result);
        }

        private static void CheckEnd(string substring, string word)
        {
            string result = word.EndsWith(substring) ? "True" : "False";
            Console.WriteLine(result);
        }

        private static string MakeUppercase(string word)
        {
            word = word.ToUpper();
            Console.WriteLine(word);
            return word;
        }

        private static void FindIndex(string v, string word)
        {
            int index = word.IndexOf(v);
            Console.WriteLine(index);
        }

        private static string Cut(int index, int count, string word)
        {
            string result = word.Substring(index, count);
            Console.WriteLine(result);
            return result;
        }
    }
}
