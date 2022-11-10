namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;
        public Rogue(string name) : base(name, ROGUE_POWER)
        {
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
