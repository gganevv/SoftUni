using System;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Decode")
            {
                string[] inputArgs = input.Split("|");
                switch (inputArgs[0])
                {
                    case "Move":
                        message = Move(int.Parse(inputArgs[1]), message);
                        break;
                    case "Insert":
                        message = Insert(int.Parse(inputArgs[1]), inputArgs[2], message);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(inputArgs[1], inputArgs[2], message);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        private static string Move(int numberOfLetters, string message)
        {
            string substring = message.Substring(0, numberOfLetters);
            string result = message.Substring(numberOfLetters, message.Length - numberOfLetters);
            result += substring;
            return result;
        }

        private static string Insert(int index, string value, string message)
        {
            return message.Insert(index, value);
        }

        private static string ChangeAll(string substring, string replacement, string message)
        {
            return message.Replace(substring, replacement);
        }
    }
}
