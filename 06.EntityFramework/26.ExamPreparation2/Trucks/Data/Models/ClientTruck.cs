using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; }
    }
}
