using System;

    class DateModifier
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            TimeSpan timeSpan = startDate - endDate;
            Console.WriteLine(Math.Abs(timeSpan.Days));
        }
    }