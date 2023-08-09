namespace RentACar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Make;

    public class Make
    {
        public Make()
        {
            this.Cars = new HashSet<Car>();
            this.Motorbikes = new HashSet<Motorbike>();
            this.Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; init; } = null!;

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Motorbike> Motorbikes { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
