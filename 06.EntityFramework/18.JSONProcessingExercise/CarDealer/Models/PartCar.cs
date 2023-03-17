namespace CarDealer.Models;

public class PartCar
{
    public virtual int PartId { get; set; }

    public virtual Part Part { get; set; } = null!;

    public virtual int CarId { get; set; }

    public virtual Car Car { get; set; } = null!; 
}
