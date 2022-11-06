namespace BirthdayCelebrations.Models.Interfaces
{
    public interface ICitizen : IIdentifable, IBirthable
    {
        string Name { get; }
        int Age { get; }
    }
}
