using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                string firstParam = commandArgs[1];
                string result = String.Empty;
                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(commandArgs[1]);
                        Exchange(index, array);
                        break;
                    case "max":
                        result = Max(firstParam, array);
                        break;
                    case "min":
                        result = Min(firstParam, array);
                        break;
                    case "first":
                        result = FirstOddEvenElements(int.Parse(firstParam), commandArgs[2], array);
                        break;
                    case "last":
                        result = LastOddEvenElements(int.Parse(firstParam), commandArgs[2], array);
                        break;
                    default:
                        break;
                }
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
        private static string FirstOddEvenElements(int maxCounter, string oddEven, int[] array)
        {
            if (maxCounter > array.Length)
            {
                return "Invalid count";
            }

            List<int> elements = new List<int>();
            int counter = 0;
            if (oddEven == "odd")
            {
                foreach (int n in array)
                {
                    if (n % 2 != 0)
                    {
                        elements.Add(n);
                        counter++;
                    }

                    if (counter == maxCounter)
                    {
                        break;
                    }
                }
            }
            else
            {
                foreach (int n in array)
                {
                    if (n % 2 == 0)
                    {
                        elements.Add(n);
                        counter++;
                    }

                    if (counter == maxCounter)
                    {
                        break;
                    }
                }
            }

            return $"[{String.Join(", ", elements)}]";
        }

        private static string LastOddEvenElements(int maxCounter, string oddEven, int[] array)
        {
            if (maxCounter > array.Length)
            {
                return "Invalid count";
            }

            List<int> elements = new List<int>();
            int counter = 0;
            if (oddEven == "odd")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0)
                    {
                        counter++;
                        elements.Add(array[i]);
                    }
                    if (counter == maxCounter)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0)
                    {
                        counter++;
                        elements.Add(array[i]);
                    }
                    if (counter == maxCounter)
                    {
                        break;
                    }
                }
            }
            elements.Reverse();
            return $"[{String.Join(", ", elements)}]";
        }


        private static string Max(string firstParam, int[] array)
        {
            int maxNum = int.MinValue;
            int maxIndex = -1;

            if (firstParam == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }

            return maxIndex >= 0 ? maxIndex.ToString() : "No matches";
        }
        private static string Min(string firstParam, int[] array)
        {
            int maxNum = int.MaxValue;
            int maxIndex = -1;

            if (firstParam == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= maxNum)
                    {
                        maxNum = array[i];
                        maxIndex = i;
                    }
                }
            }

            return maxIndex >= 0 ? maxIndex.ToString() : "No matches";
        }

        private static void Exchange(int index, int[] array)
        {
            int counter = 0;
            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            int[] newArr = new int[array.Length];
            for (int i = index + 1; i < array.Length; i++)
            {
                newArr[counter] = array[i];
                counter++;
            }

            for (int i = 0; i <= index; i++)
            {
                newArr[counter] = array[i];
                counter++;
            }

            for (int i = 0; i < newArr.Length; i++)
            {
                array[i] = newArr[i];
            }
        }

    }
}
