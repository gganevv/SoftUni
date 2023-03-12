namespace FastFood.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;
using FastFood.Common.EntityConfiguration;

public class Order
{
    public Order()
    {
        this.Id = Guid.NewGuid().ToString();
        this.OrderItems = new HashSet<OrderItem>();
    }

    [Key]
    [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string Id { get; set; }

    public string Customer { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public OrderType Type { get; set; }

    [NotMapped]
    public decimal TotalPrice { get; set; }

    [MaxLength(EntitiesValidation.GuidMaxLength)]
    [ForeignKey(nameof(Employee))]
    public string EmployeeId { get; set; } = null!;

    [Required]
    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}