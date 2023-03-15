namespace ProductShop.Models;

public class CategoryProduct
{
    public virtual int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;

    public virtual int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
