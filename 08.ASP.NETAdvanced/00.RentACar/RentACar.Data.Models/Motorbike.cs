namespace RentACar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Motorbike;

    public class Motorbike
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public Make Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public Guid AgentId { get; set; }

        public virtual Agent Agent { get; set; } = null!;

        public Guid? RenterId { get; set; }

        public User? Renter { get; set; }
    }
}
