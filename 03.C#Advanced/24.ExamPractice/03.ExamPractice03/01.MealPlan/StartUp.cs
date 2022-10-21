using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    public class StartUp
    {
        static void Main()
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            int mealsCounter = 0;

            while (meals.Any() && calories.Any())
            {
                string meal = meals.Dequeue();
                mealsCounter++;
                int currentCalories = calories.Pop();

                int mealCalories = CheckMealCalories(meal);

                int remainingCalories = currentCalories - mealCalories;
                if (remainingCalories > 0)
                {
                    calories.Push(remainingCalories);
                }
                else if(calories.Any())
                {
                    int nextDayCalories = calories.Pop();
                    calories.Push(nextDayCalories + remainingCalories);
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        private static int CheckMealCalories(string meal)
        {
            switch (meal)
            {
                case "salad":
                    return 350;
                case "soup":
                    return 490;
                case "pasta":
                    return 680;
                case "steak":
                    return 790;
                default:
                    return 0;
            }
        }
    }
}
