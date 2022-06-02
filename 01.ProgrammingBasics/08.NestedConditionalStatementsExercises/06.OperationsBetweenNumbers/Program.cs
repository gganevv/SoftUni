using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string opr = Console.ReadLine();
            double result;
            string oddEven;
            switch (opr)
            {
                case "+":
                    result = n1 + n2;
                    oddEven = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} + {n2} = {result} - {oddEven}");
                    break;
                case "-":
                    result = n1 - n2;
                    oddEven = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} - {n2} = {result} - {oddEven}");
                    break;
                case "*":
                    result = n1 * n2;
                    oddEven = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} * {n2} = {result} - {oddEven}");
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    result = (double)n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {result:f2}");
                    break;
                case "%":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }
                    result = (double)n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {result}");
                    break;
                default:
                    break;
            }
        }
    }
}