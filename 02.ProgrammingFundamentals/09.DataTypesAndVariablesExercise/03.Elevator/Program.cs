using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            double courses = Math.Ceiling((double)numberOfPeople / elevatorCapacity);
            Console.WriteLine(courses);
        }
    }
}
