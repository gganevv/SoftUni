using System;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            string checkPass = "";

            while (checkPass != password)
            {
                checkPass = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
