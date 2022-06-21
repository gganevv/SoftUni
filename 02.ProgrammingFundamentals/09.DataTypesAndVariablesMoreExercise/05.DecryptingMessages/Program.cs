using System;

namespace _05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfCharacters = int.Parse(Console.ReadLine());
            string message = "";
            for (int i = 0; i < numberOfCharacters; i++)
            {
                message += (char)(char.Parse(Console.ReadLine()) + key);
            }

            Console.WriteLine(message);
        }
    }
}
