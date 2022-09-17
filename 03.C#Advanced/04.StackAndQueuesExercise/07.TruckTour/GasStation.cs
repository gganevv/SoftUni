namespace _07.TruckTour
{
    internal class GasStation
    {
        public GasStation(int petroleum, int distance)
        {
            Petroleum = petroleum;
            Distance = distance;
        }

        public int Petroleum { get; set; }
        public int Distance { get; set; }
    }
}