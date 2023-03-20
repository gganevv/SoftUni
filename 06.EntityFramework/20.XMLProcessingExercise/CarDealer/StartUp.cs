namespace CarDealer;

using AutoMapper;

public class StartUp
{
    public static void Main()
    {

    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}