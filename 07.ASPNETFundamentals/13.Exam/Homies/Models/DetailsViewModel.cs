﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Organiser { get; set; } = null!;

        public IEnumerable<Data.Models.Type> Types { get; set; } = null!;
    }
}
