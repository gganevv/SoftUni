﻿using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Add(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiply(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    Divide(firstNumber, secondNumber);
                        break;
                default:
                    break;
            }
        }

        public static void Add(int firstNumber, int secondNumber) => Console.WriteLine(firstNumber + secondNumber);

        public static void Multiply(int firstNumber, int secondNumber) => Console.WriteLine(firstNumber * secondNumber);

        public static void Subtract(int firstNumber, int secondNumber) =>Console.WriteLine(firstNumber - secondNumber);

        private static void Divide(int firstNumber, int secondNumber) => Console.WriteLine(firstNumber / secondNumber);
    }
}
