using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants.House;

namespace HouseRentingSystem.Data.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(MinPricePerMonth, MaxPricePerMonth)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required]
        public int AgentId { get; set; }

        public Agent? Agent { get; set; }

        public string? RenterId { get; set; }
    }
}
