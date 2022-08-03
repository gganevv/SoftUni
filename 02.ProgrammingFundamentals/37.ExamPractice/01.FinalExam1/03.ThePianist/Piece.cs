namespace _03.ThePianist
{
    public class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }
}
