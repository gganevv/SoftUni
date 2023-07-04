using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstants.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Houses = new List<House>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; } = null!;
    }
}
