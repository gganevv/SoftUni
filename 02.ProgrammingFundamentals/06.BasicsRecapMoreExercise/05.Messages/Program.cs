using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < lines; i++)
            {
                string command = Console.ReadLine();
                if (command == "0")
                {
                    message += " ";
                    continue;
                }
                int numberOfDigits = command.Length;
                int mainDigit = int.Parse(command[0].ToString());
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + numberOfDigits - 1;
                message += (char)('a' + letterIndex);
            }

            Console.WriteLine(message);
        }
    }
}
