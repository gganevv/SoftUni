namespace HouseRentingSystem.Data
{
    public static class DataConstants
    {
        public static class Category
        {
           public const int NameMaxLength = 50;
        }

        public static class House
        {
            public const int TitleMaxLength = 50;

            public const int AddressMaxLength = 150;

            public const int DescriptionMaxLength = 500;

            public const int MinPricePerMonth = 0;

            public const int MaxPricePerMonth = 2000;
        }

        public static class Agent
        {
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
