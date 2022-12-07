namespace Heroes.Utilities
{
    public static class ExceptionMessages
    {
        public const string INVALID_WEAPON_NAME_EXCEPTION = "Weapon type cannot be null or empty.";

        public const string INVALID_WEAPON_DURABILITY_EXCEPTION = "Durability cannot be below 0.";

        public const string INVALID_HERO_NAME_EXCEPTION = "Hero name cannot be null or empty.";

        public const string INVALID_HERO_HEALTH_EXCEPTION = "Hero health cannot be below 0.";

        public const string INVALID_HERO_ARMOUR_EXCEPTION = "Hero armour cannot be below 0.";

        public const string NULL_WEAPON_EXCEPTION = "Weapon cannot be null.";

        public const string HERO_ALREADY_EXISTS_EXCEPTION = "The hero {0} already exists.";

        public const string INVALID_HERO_TYPE_EXCEPTION = "Invalid hero type.";

        public const string WEAPON_ALREADY_EXIST_EXCEPTION = "The weapon {0} already exists.";

        public const string INVALID_WEAPON_TYPE_EXCEPTION = "Invalid weapon type.";

        public const string HERO_DOES_NOT_EXIST_EXCEPTION = "Hero {0} does not exist.";

        public const string WEAPON_DOES_NOT_EXIST_EXCEPTION = "Weapon {0} does not exist.";

        public const string HERO_ALREADY_HAVE_WEAPON = "Hero {0} is well-armed.";

    }
}
