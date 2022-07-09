using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Songs
{
    public class Song
    {

        public Song(string songTypeList, string songName, string songTime)
        {
            this.TypeList = songTypeList;
            this.Name = songName;
            this.Time = songTime;
        }

        public string TypeList { get; set; }
        public string  Name { get; set; }
        public string  Time { get; set; }
    }
}
