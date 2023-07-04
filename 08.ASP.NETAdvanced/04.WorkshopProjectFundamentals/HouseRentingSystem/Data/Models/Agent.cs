using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants.Agent;

namespace HouseRentingSystem.Data.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Userid { get; set; } = null!;

        public IdentityUser? User { get; set; }
    }
}
