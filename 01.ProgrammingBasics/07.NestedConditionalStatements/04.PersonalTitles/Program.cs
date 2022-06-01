using System;

namespace _04.PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            string title;
            if (gender == 'm')
            {
                if (age >= 16)
                {
                    title = "Mr.";
                }
                else
                {
                    title = "Master";
                }
            }
            else
            {
                if (age >= 16)
                {
                    title = "Ms.";
                }
                else
                {
                    title = "Miss";
                }
            }
            Console.WriteLine(title);
        }
    }
}
