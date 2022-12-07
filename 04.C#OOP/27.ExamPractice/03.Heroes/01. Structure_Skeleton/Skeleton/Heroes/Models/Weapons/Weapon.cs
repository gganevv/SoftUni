namespace Heroes.Models.Weapons
{
    using System;
    
    using Contracts;
    using Utilities;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_WEAPON_NAME_EXCEPTION);
                }

                name = value;
            }
        }

        public int Durability
        {
            get => durability;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_WEAPON_DURABILITY_EXCEPTION);
                }

                durability = value;
            }
        }

        public abstract int DoDamage();
    }
}
