namespace BorderControl.Models.Interfaces
{
    public interface ICitizen : IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
