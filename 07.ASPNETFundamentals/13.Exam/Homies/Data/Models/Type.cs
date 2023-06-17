using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; }
    }
}
