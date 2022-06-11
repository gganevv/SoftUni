using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainers = int.Parse(Console.ReadLine());
            double totalpoints = 0;
            string command = Console.ReadLine();
            int presentationCounter = 0;
            while (command != "Finish")
            {
                string currentPresentation = command;
                double currentGrade = 0;
                for (int i = 0; i < trainers; i++)
                {
                    currentGrade += double.Parse(Console.ReadLine());
                }
                totalpoints += currentGrade;
                Console.WriteLine($"{currentPresentation} - {currentGrade / trainers:f2}.");
                presentationCounter++;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalpoints / (presentationCounter * trainers):f2}.");
        }
    }
}
