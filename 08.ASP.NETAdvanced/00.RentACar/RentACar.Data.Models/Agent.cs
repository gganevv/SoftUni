namespace RentACar.Data.Models
{
using System.ComponentModel.DataAnnotations;

    public class Agent
    {
        [Key]
        public Guid Id { get; set; }
    }
}
