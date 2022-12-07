namespace Heroes.Models.Heroes
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_NAME_EXCEPTION);
                }

                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_HEALTH_EXCEPTION);
                }

                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_ARMOUR_EXCEPTION);
                }

                armour = value;
            }
        }

        public IWeapon Weapon => weapon;

        public bool IsAlive => Health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException(ExceptionMessages.NULL_WEAPON_EXCEPTION);
            }

            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (Armour < points)
            {
                points -= Armour;
                Armour = 0;
            }
            else
            {
                Armour -= points;
                points = 0;
            }


            if (Health < points)
            {
                Health = 0;
            }
            else
            {
                Health -= points;
            }
        }
    }
}
