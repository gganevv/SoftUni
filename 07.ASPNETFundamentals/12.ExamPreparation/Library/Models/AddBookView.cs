using Library.Data;
using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookView
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        public string Url { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
