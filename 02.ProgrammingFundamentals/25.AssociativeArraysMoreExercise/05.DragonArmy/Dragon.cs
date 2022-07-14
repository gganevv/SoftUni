namespace _05.DragonArmy
{
    public class Dragon
    {
        public Dragon(string type, string name, int damage, int health, int armor)
        {
            Type = type;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public string DragonType { get; }
        public string DragonName { get; }

        public override string ToString()
        {
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }
}
