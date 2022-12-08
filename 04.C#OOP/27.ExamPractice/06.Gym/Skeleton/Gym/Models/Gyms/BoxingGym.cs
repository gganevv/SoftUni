namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int MAX_CAPACITY = 15;
        public BoxingGym(string name) : base(name, MAX_CAPACITY)
        {
        }
    }
}