using System;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;
        public Druid(string name) : base(name, DRUID_POWER)
        {
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
