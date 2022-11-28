namespace _02.Facade
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("BMW")
                    .WithColor("Black")
                    .WithNumberOfDoors(5)
                .Built
                    .inCity("Leipzig ")
                    .AtAddress("Some address 254")
                    .Build();

            Console.WriteLine(car);
        }
    }
}
