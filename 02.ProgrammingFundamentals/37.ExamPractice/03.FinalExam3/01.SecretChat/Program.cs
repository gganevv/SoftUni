using System;
using System.Linq;

namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                string[] commandArgs = input.Split(":|:");
                string command = commandArgs[0];
                switch (command)
                {
                    case "InsertSpace":
                        message = InsertSpace(int.Parse(commandArgs[1]), message);
                        break;
                    case "Reverse":
                        string substring = commandArgs[1];
                        if (message.Contains(substring))
                        {
                            message = message.Remove(message.IndexOf(substring), substring.Length);
                            message = message + String.Join("", substring.Reverse());
                        }
                        else
                        {
                            Console.WriteLine("error");
                            input = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        message = ChangeAll(commandArgs[1], commandArgs[2], message);
                        break;
                    default:
                        break;
                }
                Console.WriteLine(message);
                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        static string InsertSpace(int index, string message)
        {
            return message.Insert(index, " ");
        }

        static string ChangeAll(string substring, string replacement, string message)
        {
            return message.Replace(substring, replacement);
        }
    }
}
