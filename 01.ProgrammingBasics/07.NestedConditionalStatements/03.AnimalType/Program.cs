using System;

namespace _03.AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string animalName = Console.ReadLine();
            string animalType;
            switch (animalName)
            {
                case "dog":
                    animalType = "mammal";
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    animalType = "reptile";
                    break;
                default:
                    animalType = "unknown";
                    break;
            }
            Console.WriteLine(animalType);
        }
    }
}
