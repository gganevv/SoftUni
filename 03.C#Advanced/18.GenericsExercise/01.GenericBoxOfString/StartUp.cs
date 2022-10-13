using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            int countOfItems = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfItems; i++)
            {
                string value = Console.ReadLine();
                Box<string> box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}
