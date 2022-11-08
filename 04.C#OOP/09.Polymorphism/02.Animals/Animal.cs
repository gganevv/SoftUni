namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }
        public string Name { get; protected set; }
        public string FavoriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favorite food is {FavoriteFood}";
        }
    }
}
