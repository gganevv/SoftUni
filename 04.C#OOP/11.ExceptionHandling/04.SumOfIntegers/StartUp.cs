namespace _04.SumOfIntegers
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            int sum = 0;
            string[] elements = Console.ReadLine().Split();
            foreach (var element in elements)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
