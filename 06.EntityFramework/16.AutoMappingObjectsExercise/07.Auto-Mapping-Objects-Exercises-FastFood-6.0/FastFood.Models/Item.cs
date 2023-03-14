namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FastFood.Common.EntityConfiguration;

public class Item
{
    public Item()
    {
        this.Id = Guid.NewGuid().ToString();
        this.OrderItems = new HashSet<OrderItem>();
    }

    [Key]
    public string Id { get; set; }

    [MaxLength(ViewModelsValidation.ItemNameMaxLength)]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [Required]
    public virtual Category Category { get; set; } = null!;

    
    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}