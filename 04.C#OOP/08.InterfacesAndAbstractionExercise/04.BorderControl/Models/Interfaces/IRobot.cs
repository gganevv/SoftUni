using System.Security.Cryptography.X509Certificates;

namespace BorderControl.Models.Interfaces
{
    public interface IRobot : IIdentifiable
    {
        public string Model { get; }
    }
}
