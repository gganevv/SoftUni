using Microsoft.AspNetCore.Identity;
using static RentACar.Common.EntityValidationConstants;

namespace RentACar.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.RenedCars = new HashSet<Car>();
            this.RenedMotorbikes = new HashSet<Motorbike>();
            this.RenedTrucks = new HashSet<Truck>();
        }

        public virtual ICollection<Car> RenedCars { get; set; }

        public virtual ICollection<Motorbike> RenedMotorbikes { get; set; }

        public virtual ICollection<Truck> RenedTrucks { get; set; }

    }
}
