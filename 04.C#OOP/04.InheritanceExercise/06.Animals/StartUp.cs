using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            string type = Console.ReadLine();

            while (type != "Beast!")
            {
                string[] animalProp = Console.ReadLine().Split();
                string name = animalProp[0];
                int age = int.Parse(animalProp[1]);
                string gender = string.Empty;
                if (animalProp.Length > 2)
                {
                    gender = animalProp[2];
                }
                

                Animal animal = null;

                try
                {
                    switch (type)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (animal != null) Console.WriteLine(animal);

                type = Console.ReadLine();
            }
        }
    }
}
