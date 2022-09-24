using System.Collections.Generic;

namespace _07.TheV_Logger
{
    public class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Followers = new List<string>();
            Following = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Followers.Count} followers, {Following.Count} following";
        }
    }
}
