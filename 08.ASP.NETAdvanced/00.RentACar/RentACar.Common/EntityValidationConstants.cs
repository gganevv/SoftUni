namespace RentACar.Common
{
    public static class EntityValidationConstants
    {
        public static class Car
        {
            public const int TitleMinLength = 10;

            public const int TitleMaxLength = 50;
        }

        public static class Motorbike
        {
            public const int TitleMinLength = 10;

            public const int TitleMaxLength = 50;
        }

        public static class Truck
        {
            public const int TitleMinLength = 10;

            public const int TitleMaxLength = 50;
        }

        public static class Make
        {
            public const int NameMinLength = 2;

            public const int NameMaxLength = 20;
        }
    }
}
