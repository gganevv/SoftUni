namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;
        public Warrior(string name) : base(name, WARRIOR_POWER)
        {
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
