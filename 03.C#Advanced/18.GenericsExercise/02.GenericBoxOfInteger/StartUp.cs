using System;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfItems = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfItems; i++)
            {
                int value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                Console.WriteLine(box);
            }
        }
    }
}
