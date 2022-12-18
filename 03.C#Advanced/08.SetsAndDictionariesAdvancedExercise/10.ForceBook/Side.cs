using System;
using System.Collections.Generic;

namespace _10.ForceBook
{
    public class Side
    {
        public Side(string name)
        {
            Name = name;
            Memebers = new List<string>();
        }

        public string Name { get; set; }
        public List<String> Memebers { get; set; }
    }
}