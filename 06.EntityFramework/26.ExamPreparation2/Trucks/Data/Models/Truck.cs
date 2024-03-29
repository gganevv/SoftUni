﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models;

using Trucks.Data.Models.Enums;

public class Truck
{
    public Truck()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(8)]
    public string RegistrationNumber { get; set; } = null!;

    [MaxLength(17)]
    public string VinNumber { get; set; } = null!;

    public int TankCapacity { get; set; }

    public int CargoCapacity { get; set; }

    public CategoryType CategoryType { get; set; }

    public MakeType MakeType { get; set; }

    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set; }

    public virtual Despatcher Despatcher { get; set; }

    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
}
