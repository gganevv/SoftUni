namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public int NumberOfToppings => toppings.Count;
        public double TotalCalories => GetTotalCalories();

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            double totalCalories = 0;
            totalCalories += dough.TotalCalories;
            foreach (var topping in toppings)
            {
                totalCalories += topping.TotalCalories;
            }
            return totalCalories;
        }
    }
}
