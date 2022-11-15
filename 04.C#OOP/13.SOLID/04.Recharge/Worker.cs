namespace Recharge
{
    public abstract class Worker
    {
        private int workingHours;

        public Worker()
        {
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}
