namespace _02.EnterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                try
                {
                    int currentNum = int.Parse(Console.ReadLine());
                    if (!numbers.Any())
                    {
                        ReadNumber(1, 100, currentNum, numbers);
                    }
                    else
                    {
                        ReadNumber(numbers[numbers.Count - 1], 100, currentNum, numbers);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void ReadNumber(int start, int end, int number, List<int> numbers)
        {
            if (number <= start || number >= end)
            {
                if (numbers.Any())
                {
                    throw new ArgumentException($"Your number is not in range {numbers[numbers.Count - 1]} - 100!");
                }
                else
                {
                    throw new ArgumentException($"Your number is not in range 1 - 100!");
                }
                
            }
            else
            {
                numbers.Add(number);
            }
        }
    }
}