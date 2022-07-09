using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                input = BoxParser(input, boxes);
            }

            boxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            boxes.ForEach(x => Console.WriteLine(x));
        }

        private static string BoxParser(string input, List<Box> boxes)
        {
            string[] inputArgs = input.Split();
            Item item = new Item(inputArgs[1], double.Parse(inputArgs[3]));
            Box box = new Box(int.Parse(inputArgs[0]), item, int.Parse(inputArgs[2]));
            boxes.Add(box);
            input = Console.ReadLine();
            return input;
        }
    }
}
