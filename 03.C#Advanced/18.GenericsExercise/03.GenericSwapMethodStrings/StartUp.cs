using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main()
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int countOfBoxes = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfBoxes; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            int[] elementsToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SwapElemet(elementsToSwap[0], elementsToSwap[1], boxes);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void SwapElemet<T>(int firstIndex, int secondIndex, List<T> boxes)
        {
            T temp = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}
