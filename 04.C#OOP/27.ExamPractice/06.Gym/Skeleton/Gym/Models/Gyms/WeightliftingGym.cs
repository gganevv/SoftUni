namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int MAX_CAPACITY = 20;
        public WeightliftingGym(string name) : base(name, MAX_CAPACITY)
        {
        }
    }
}