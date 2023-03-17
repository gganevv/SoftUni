﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.Models;

public class PartCar
{
    [ForeignKey(nameof(Part))]
    public virtual int PartId { get; set; }

    public virtual Part Part { get; set; } = null!;

    [ForeignKey(nameof(Car))]
    public virtual int CarId { get; set; }

    public virtual Car Car { get; set; } = null!; 
}
