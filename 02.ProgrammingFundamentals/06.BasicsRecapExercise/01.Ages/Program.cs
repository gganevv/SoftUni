using System;

namespace _01.Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that determines if a person is baby, child, teenager,
            //adult or elder based on the given age. The boundaries are:
            //0 - 2 – baby
            //3 - 13 – child
            //14 - 19 – teenager
            //20 - 65 – adult
            //>= 66 – elder
            //All the values are inclusive.

            int age = int.Parse(Console.ReadLine());
            string result = "";
            if (age <= 2)
            {
                result = "baby";
            }
            else if (age > 2 && age <= 13)
            {
                result = "child";
            }
            else if (age > 13 && age <= 19)
            {
                result = "teenager";
            }
            else if (age > 19 && age <= 65)
            {
                result = "adult";
            }
            else
            {
                result = "elder";
            }

            Console.WriteLine(result);
        }
    }
}
