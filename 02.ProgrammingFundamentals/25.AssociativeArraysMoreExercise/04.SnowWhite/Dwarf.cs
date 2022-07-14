namespace _04.SnowWhite
{
    public class Dwarf
    {
        public Dwarf(string name, string hatColor, int phisics)
        {
            Name = name;
            HatColor = hatColor;
            Phisics = phisics;
        }
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Phisics { get; set; }
        public override string ToString()
        {
            return $"({HatColor}) {Name} <-> {Phisics}";
        }
    }
}
