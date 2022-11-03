namespace _04.PizzaCalories
{
    //92/100
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Pizza pizza = new Pizza(pizzaArgs[1]);
                string[] doughtArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                pizza.Dough = new Dough(doughtArgs[1], doughtArgs[2], double.Parse(doughtArgs[3]));

                string topping = Console.ReadLine();
                while (topping != "END")
                {
                    string[] toppingArgs = topping.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    pizza.AddTopping(new Topping(toppingArgs[1], int.Parse(toppingArgs[2])));

                    topping = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
