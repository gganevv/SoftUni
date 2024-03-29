﻿namespace ProductShop.Models;

using System.Collections.Generic;

public class Product
{
    public Product()
    {
        this.CategoryProducts = new HashSet<CategoryProduct>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual int SellerId { get; set; }
    public virtual User Seller { get; set; } = null!;

    public virtual int? BuyerId { get; set; }
    public virtual User? Buyer { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
}