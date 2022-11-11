namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models;
    using WildFarm.Models.Food;

    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                string animalType = commandArgs[0];
                string name = commandArgs[1];
                double weight = double.Parse(commandArgs[2]);
                Animal animal;
                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(name, weight, commandArgs[3], commandArgs[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(name, weight, commandArgs[3], commandArgs[4]);
                        break;
                    case "Hen":
                        animal = new Hen(name, weight, double.Parse(commandArgs[3]));
                        break;
                    case "Owl":
                        animal = new Owl(name, weight, double.Parse(commandArgs[3]));
                        break;
                    case "Dog":
                        animal = new Dog(name, weight, commandArgs[3]);
                        break;
                    case "Mouse":
                        animal = new Mouse(name, weight, commandArgs[3]);
                        break;
                    default:
                        animal = null;
                        break;
                }
                animals.Add(animal);

                string[] foodArgs = Console.ReadLine().Split();
                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);
                Console.WriteLine(animal.ProduceSound());

                Food food;
                switch (foodType)
                {
                    case "Vegetable": food = new Vegetable(foodQuantity); break;
                    case "Fruit": food = new Fruit(foodQuantity); break;
                    case "Meat": food = new Meat(foodQuantity); break;
                    case "Seeds": food = new Seeds(foodQuantity); break;
                    default: food = null; break;
                }
                try
                {
                    animal.Feed(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
