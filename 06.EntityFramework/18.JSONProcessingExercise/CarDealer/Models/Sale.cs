namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sale
{
    [Key]
    public int Id { get; set; }

    public decimal Discount { get; set; }

    [ForeignKey(nameof(Car))]
    public virtual int CarId { get; set; }

    public virtual Car Car { get; set; } = null!;

    [ForeignKey(nameof(Customer))]
    public virtual int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!; 
}
